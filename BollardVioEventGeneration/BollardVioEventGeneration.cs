using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bollard;

namespace BollardVioEventGeneration
{
    public class BollardVioEventGeneration
    {
        private int _CustomerId;
        private int _VendorId;

        private DateTime _CustomerDateTime;
        private string _ConnString;
       // private BollardVioEventEntities bioEventDataEntity = null;

        public BollardVioEventGeneration(int CustomerID, int VendorId = 0)
        {
            _CustomerId = CustomerID;
            _VendorId = VendorId;
            _ConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            _CustomerDateTime = Utilities.GetCustomerPresentTime(this._ConnString, this._CustomerId);
        }

        public void ChangeGenerationDate(DateTime dtRequiredDate)
        {//This would be useful to generate the events for any particular date
            _CustomerDateTime = dtRequiredDate;
        }

        public void GenerateBollardVioEvent()
        {
            try
            {
                //0. Create a datatable similar to EnfBollardVioEventTest.
                //1. Get meters from PSOA for the last 24 hours.

                using (var bioEventDataEntity = new BollardVioEventEntities())
                {
                    DateTime dtFromDate = this._CustomerDateTime.AddHours(-24);
                    var MetersList = bioEventDataEntity.ParkingSpaceOccupancyAudits
                        .Where(b => b.GCustomerid == this._CustomerId 
                        && b.GMeterId == 32022 //REMOVE THIS AFTER TESTING
                        && b.RecCreationDate.Value >= dtFromDate).OrderBy(o => o.LastUpdatedTS);
                    
                    foreach (var meter in MetersList)
                    {
                        //2. for each meter, check the last status.
                        //2a. insert a datarow for this meter 

                        //get meter details
                        var meterItem = bioEventDataEntity.Meters
                                        .FirstOrDefault(m => m.CustomerID == meter.GCustomerid
                                            && m.AreaID == meter.GAreaId
                                            && m.MeterId == meter.GMeterId);
                        var mmItem = meterItem.MeterMaps.FirstOrDefault();

                        //get bio details
                        var bioItem = bioEventDataEntity.BOLLARDIMAGEOCCUPANCies
                                    .FirstOrDefault(b => b.CustomerId == meter.GCustomerid
                                                        && b.MeterId == meter.GMeterId
                                                        && b.ImageTS == meter.LastUpdatedTS);
                        string Image = "EntryImage";
                        string PlateNumber = null, State = null, Make = null, Model = null, Color = null;


                        if (bioItem != null)
                        {
                            string[] dtFileNameArray = bioItem.FileName.Split(new string[] { "##" }, StringSplitOptions.RemoveEmptyEntries);
                            string dtFolder = dtFileNameArray[0];
                            Image = $@"https://pems.pemsportal.com/PemsImages/{_CustomerId}/{dtFolder}/{dtFileNameArray[1]}";
                            PlateNumber = bioItem.PlateAlternate;
                            State = bioItem.StateAlternate;
                            Make = bioItem.Make;
                            Model = bioItem.Model;
                            Color = bioItem.Color;
                        }

                        if (meter.LastStatus == 1)
                        {
                            //decide new event or existing event
                            using (var bioEventContext = new BollardVioEventEntities())
                            {
                                var vioEvent = bioEventContext.enfbollardvioeventTests
                                                .Where(v => v.EnfCustomerId == meter.GCustomerid
                                                            && v.AreaId == meter.GAreaId
                                                            && v.EnfPayStationId == meter.GMeterId
                                                            && v.LPEntryDatetime <= meter.LastUpdatedTS
                                                            && (v.LPExitDatetime == null || v.LPExitDatetime >= meter.LastUpdatedTS))
                                                .OrderBy(o => o.LPEntryDatetime)
                                                .FirstOrDefault();
                                if (vioEvent == null)
                                {//insert first in
                                    vioEvent = new enfbollardvioeventTest();
                                    vioEvent.EnfCustomerId = meter.GCustomerid;
                                    vioEvent.AreaId = meter.GAreaId;
                                    vioEvent.EnfPayStationId = meter.GMeterId;
                                    vioEvent.LPEntryDatetime = meter.LastUpdatedTS;

                                    vioEvent.GlobalMeterId = meterItem.GlobalMeterId; //this needs to be fetched.
                                    vioEvent.Name = meterItem.MeterName;//This needs to be fetched.
                                    vioEvent.EnfVendorId = this._VendorId;
                                    vioEvent.EnfZoneId = mmItem.ZoneId; //this needs to be fetched.
                                    vioEvent.EnfZoneName = mmItem.Zone.ZoneName; //this needs to be fetched.
                                    vioEvent.SpaceName = null;

                                    vioEvent.ExpectedAmount = 0; //this needs to be fetched.
                                    vioEvent.PaymentAmount = null;
                                    vioEvent.PaymentStartTime = null;
                                    vioEvent.PaymentEndTime = null;

                                    vioEvent.EntryImage = Image;
                                    vioEvent.PlateNumber = PlateNumber;
                                    vioEvent.State = State;

                                    vioEvent.TicketNo = null;
                                    vioEvent.IsWarning = 0;//this is now defaulted to 0.

                                    if (vioEvent.PaymentStartTime.HasValue == false) //need to add other conditions
                                    {
                                        vioEvent.ViolatedStatus = 0;
                                        vioEvent.ViolationDuration = (int)Math.Ceiling((_CustomerDateTime - vioEvent.LPEntryDatetime).Value.TotalHours);
                                    }

                                    vioEvent.CreatedOn = DateTime.Now;
                                    bioEventContext.enfbollardvioeventTests.Add(vioEvent);
                                    bioEventContext.SaveChanges();
                                }
                                else
                                {
                                    //already in event started. so we can ignore this event or update the late Ins
                                }
                            }
                                
                        }
                        if (meter.LastStatus == 2)
                        {
                            //usually update event
                            using (var bioEventContext = new BollardVioEventEntities())
                            {
                                var vioEvent = bioEventContext.enfbollardvioeventTests
                                                .Where(v => v.EnfCustomerId == meter.GCustomerid
                                                            && v.AreaId == meter.GAreaId
                                                            && v.EnfPayStationId == meter.GMeterId
                                                            && v.LPEntryDatetime <= meter.LastUpdatedTS
                                                            && v.LPExitDatetime.HasValue == false
                                                            )
                                                .OrderBy(o => o.LPEntryDatetime)
                                                .FirstOrDefault();
                                if (vioEvent != null)
                                {//update exit time, exit image
                                    vioEvent.LPExitDatetime = meter.LastUpdatedTS;
                                    vioEvent.ExitImage = Image;
                                    vioEvent.ModifiedOn = DateTime.Now; 
                                    bioEventContext.enfbollardvioeventTests.Attach(vioEvent);
                                    bioEventContext.Entry(vioEvent).State = System.Data.Entity.EntityState.Modified;
                                    bioEventContext.SaveChanges();
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
