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
    
    public partial class HousingMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HousingMaster()
        {
            this.MeterMaps = new HashSet<MeterMap>();
        }
    
        public int HousingId { get; set; }
        public string HousingName { get; set; }
        public int Customerid { get; set; }
        public string Block { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string StreetDirection { get; set; }
        public string StreetNotes { get; set; }
        public Nullable<int> HousingTypeID { get; set; }
        public string DoorLockId { get; set; }
        public string MechLockId { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> InactiveRemarkID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string Notes { get; set; }
        public Nullable<int> OldHousingId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeterMap> MeterMaps { get; set; }
    }
}
