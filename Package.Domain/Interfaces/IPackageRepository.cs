using Package.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Domain.Interfaces
{
    public interface IPackageRepository
    {
        Task<string> CreatePackage(PackageEntity datos);
    }
}
