using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BollardVioEventEntity
{
    public class ParkingSpaceOccupancyAudit
    {
        public long AuditID { get; set; }
        public long ParkingSpaceOccupancyId { get; set; }
        public int LastStatus { get; set; }
        public System.DateTime LastUpdatedTS { get; set; }
        public Nullable<System.DateTime> RecCreationDate { get; set; }
        public string ResultStatus { get; set; }
        public Nullable<int> GCustomerid { get; set; }
        public Nullable<int> GAreaId { get; set; }
        public Nullable<int> GMeterId { get; set; }
        public byte[] DiagnosticData { get; set; }
        public Nullable<int> Regulated { get; set; }
        public Nullable<int> TimeType1 { get; set; }
        public Nullable<int> TimeType2 { get; set; }
        public Nullable<int> TimeType3 { get; set; }
        public Nullable<int> TimeType4 { get; set; }
        public Nullable<int> TimeType5 { get; set; }
        public Nullable<System.DateTime> EndTS { get; set; }
        public Nullable<int> DurationSeconds { get; set; }
        public Nullable<int> LQI { get; set; }
        public Nullable<int> GwayCustomerId { get; set; }
        public Nullable<int> GwayAreaId { get; set; }
        public Nullable<int> GwayMeterId { get; set; }
    }
}
