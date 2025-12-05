using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Application.Interfaces
{
    public interface IPackageUseCase
    {
        Task<string> Create();
    }
}
