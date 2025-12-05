using Package.Application.Interfaces;

namespace Package.Application.UseCase
{
    public class PackageUseCase : IPackageUseCase
    {
        public async Task<string> Create()
        {
            var response = "Retornando producto";
            return await Task.FromResult(response);
        }
    }
}
