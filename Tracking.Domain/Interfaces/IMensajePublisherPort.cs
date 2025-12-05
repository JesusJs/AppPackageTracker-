using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Domain.Interfaces
{
    public interface IMensajePublisherPort
    {
        void Publicar(string mensaje, string routingKey);
    }
}
