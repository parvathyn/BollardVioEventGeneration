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
    
    public partial class BOLLARDIMAGEOCCUPANCY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOLLARDIMAGEOCCUPANCY()
        {
            this.BollardImages = new HashSet<BollardImage>();
        }
    
        public long Id { get; set; }
        public Nullable<long> AuditID { get; set; }
        public Nullable<long> ParkingSpaceOccupancyId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> MeterId { get; set; }
        public string FileName { get; set; }
        public string FileLayout { get; set; }
        public string PlateAlternate { get; set; }
        public string StateAlternate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> PlateScore { get; set; }
        public string PlateDetails { get; set; }
        public Nullable<int> BollardPeerID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> IsActive { get; set; }
        public string OldPlateAlternate { get; set; }
        public string PlateModifiedBy { get; set; }
        public Nullable<System.DateTime> PlateModifiedOn { get; set; }
        public string Source { get; set; }
        public string PlateIdentified { get; set; }
        public Nullable<int> SourceID { get; set; }
        public Nullable<System.DateTime> ImageTS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BollardImage> BollardImages { get; set; }
    }
}
