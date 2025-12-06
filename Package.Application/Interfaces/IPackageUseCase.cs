using Package.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Application.Interfaces
{
    public interface IPackageUseCase
    {
        Task<(bool Success, string response)> Create(PackageModels datos);
        Task<PackageModels?> GetById(int id);
        Task<(bool Success, bool Exists)> Update(int id, PackageModels model);
        Task<(bool Success, bool Exists)> Delete(int id);
    }
}
