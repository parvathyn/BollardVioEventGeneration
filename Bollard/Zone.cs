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
    
    public partial class Zone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zone()
        {
            this.MeterMaps = new HashSet<MeterMap>();
        }
    
        public int ZoneId { get; set; }
        public int customerID { get; set; }
        public string ZoneName { get; set; }
        public Nullable<int> ZoneStatus { get; set; }
        public Nullable<int> RoadID { get; set; }
        public string StreetName { get; set; }
        public string BlockFrom { get; set; }
        public string BlockTo { get; set; }
        public Nullable<int> AreaId { get; set; }
        public Nullable<int> SubArea { get; set; }
        public Nullable<int> LengthOfZone { get; set; }
        public Nullable<int> TCMinuteNumber { get; set; }
        public Nullable<System.DateTime> TCDate { get; set; }
        public Nullable<System.DateTime> InstallDate { get; set; }
        public Nullable<int> DataWorks { get; set; }
        public Nullable<System.DateTime> SupresededDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeterMap> MeterMaps { get; set; }
    }
}