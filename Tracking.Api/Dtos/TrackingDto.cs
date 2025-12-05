using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Api.Dtos
{
    public class TrackingDto
    {
        public required DateTime Date { get; set; }
        public required string Location { get; set; }
        public required string StateType { get; set; }
    }
}
