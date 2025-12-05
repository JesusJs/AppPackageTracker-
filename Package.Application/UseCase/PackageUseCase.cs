using AutoMapper;
using Package.Application.Interfaces;
using Package.Domain.Entity;
using Package.Domain.Interfaces;
using Package.Domain.Models;

namespace Package.Application.UseCase
{
    public class PackageUseCase : IPackageUseCase
    {
        private readonly IMapper? _mapper;
        private readonly IPackageRepository _repo;

        public PackageUseCase(IMapper mapper, IPackageRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<string> Create(PackageModels datos)
        {
            var response = await _repo.CreatePackage(_mapper.Map<PackageEntity>(datos));

            return response;
        }
    }
}