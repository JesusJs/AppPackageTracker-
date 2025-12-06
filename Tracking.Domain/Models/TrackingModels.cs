using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Domain.Models
{
    public class TrackingModels
    {
        public int Id { get; set; }
        public int HistoryID { get; set; }
        public required string PackageTrackingID { get; set; }
        public required string Location { get; set; }
        public required DateTime Timestamp { get; set; }
    }
}
