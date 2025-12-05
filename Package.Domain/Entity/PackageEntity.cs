using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Domain.Entity
{
    public class PackageEntity
    {
        public int Id { get; set; }
        public required string Origin { get; set; }
        public required string Destination { get; set; }
        public required string Peso { get; set; }
        public required string EstadoActual { get; set; }
    }
}
