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
        public required DateTime Date { get; set; }
        public required string Location { get; set; }
        public required string StateType { get; set; }
    }
}
