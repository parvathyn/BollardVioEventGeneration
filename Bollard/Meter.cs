//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bollard
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meter()
        {
            this.MeterMaps = new HashSet<MeterMap>();
        }
    
        public Nullable<long> GlobalMeterId { get; set; }
        public int CustomerID { get; set; }
        public int AreaID { get; set; }
        public int MeterId { get; set; }
        public string SMSNumber { get; set; }
        public int MeterStatus { get; set; }
        public int TimeZoneID { get; set; }
        public int MeterRef { get; set; }
        public string EmporiaKey { get; set; }
        public string MeterName { get; set; }
        public string Location { get; set; }
        public Nullable<int> BayStart { get; set; }
        public Nullable<int> BayEnd { get; set; }
        public string Description { get; set; }
        public string GSMNumber { get; set; }
        public int SchedServTime { get; set; }
        public string RSFName { get; set; }
        public Nullable<System.DateTime> RSFDateTime { get; set; }
        public string BarCode { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public string ProgramName { get; set; }
        public Nullable<int> MaxBaysEnabled { get; set; }
        public Nullable<int> MeterType { get; set; }
        public Nullable<int> MeterGroup { get; set; }
        public Nullable<int> MParkID { get; set; }
        public Nullable<int> MeterState { get; set; }
        public Nullable<int> DemandZone { get; set; }
        public Nullable<int> TypeCode { get; set; }
        public Nullable<int> OperationalStatusID { get; set; }
        public Nullable<System.DateTime> InstallDate { get; set; }
        public Nullable<int> FreeParkingMinute { get; set; }
        public Nullable<int> RegulatedStatusID { get; set; }
        public Nullable<System.DateTime> WarrantyExpiration { get; set; }
        public Nullable<System.DateTime> OperationalStatusTime { get; set; }
        public Nullable<System.DateTime> LastPreventativeMaintenance { get; set; }
        public Nullable<System.DateTime> NextPreventativeMaintenance { get; set; }
        public Nullable<System.DateTime> OperationalStatusEndTime { get; set; }
        public string OperationalStatusComment { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeterMap> MeterMaps { get; set; }
    }
}