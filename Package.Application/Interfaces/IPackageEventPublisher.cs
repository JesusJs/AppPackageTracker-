using Package.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Application.Interfaces
{
    public interface IPackageEventPublisher
    {
       Task<string> PublishPackageCreated(string message);
    }
}
