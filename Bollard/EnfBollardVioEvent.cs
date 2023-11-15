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
    
    public partial class EnfBollardVioEvent
    {
        public long Id { get; set; }
        public Nullable<long> EnfCustomerId { get; set; }
        public Nullable<long> EnfVendorId { get; set; }
        public Nullable<int> AreaId { get; set; }
        public Nullable<long> EnfPayStationId { get; set; }
        public Nullable<long> GlobalMeterId { get; set; }
        public string Name { get; set; }
        public string SpaceName { get; set; }
        public Nullable<long> EnfZoneId { get; set; }
        public string EnfZoneName { get; set; }
        public string PlateNumber { get; set; }
        public string State { get; set; }
        public Nullable<System.DateTime> LPEntryDatetime { get; set; }
        public Nullable<System.DateTime> LPExitDatetime { get; set; }
        public Nullable<int> ExpectedAmount { get; set; }
        public string EntryImage { get; set; }
        public string ExitImage { get; set; }
        public Nullable<System.DateTime> PaymentStartTime { get; set; }
        public Nullable<System.DateTime> PaymentEndTime { get; set; }
        public Nullable<int> PaymentAmount { get; set; }
        public Nullable<int> ViolatedStatus { get; set; }
        public Nullable<int> ViolationDuration { get; set; }
        public Nullable<int> IsWarning { get; set; }
        public string TicketNo { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public Nullable<int> PaymentStatus { get; set; }
        public string PaymentStatusReason { get; set; }
        public Nullable<System.DateTime> PaymentStatusTime { get; set; }
    }
}
