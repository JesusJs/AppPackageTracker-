using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Domain.Entity
{
    public class PackageEntity
    {
        public required string Id { get; set; }
        public required string TrackingID { get; set; }
        public required string RecipientName { get; set; }
        public required string RecipientAddress { get; set; }
        public required decimal Weight { get; set; }
        public required decimal Height { get; set; }
        public required decimal Width { get; set; }
        public required decimal Depth { get; set; }
        public required string CurrentState { get; set; }
    }
}
