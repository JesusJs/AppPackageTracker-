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
        private readonly IPackageEventPublisher _publisher;

        public PackageUseCase(IMapper mapper, IPackageRepository repo, IPackageEventPublisher publisher)
        {
            _mapper = mapper;
            _repo = repo;
            _publisher = publisher;
        }
        public async Task<(bool Success, string response)> Create(PackageModels datos)
        {
            var response = await _repo.CreatePackage(_mapper.Map<PackageEntity>(datos));

            return (Success: true, response: response);
        }

        // Queme estos datos solo para ir teniendo la logica 
        public async Task<PackageModels?> GetById(int id)
        {
            var myPackage = new PackageModels
            {
                TrackingID = "LT-987654321",
                RecipientName = "Ana Martínez",
                RecipientAddress = "Avenida Siempre Viva 742, Springfield",
                Weight = 2.5m,
                Height = 15.0m,
                Width = 20.0m,
                Depth = 5.0m,
                CurrentState = "CREATED"
            };

            var prueba =  await _publisher.PublishPackageCreated("Obteniendo datos por id");

            return  myPackage;
        }

        public async Task<(bool Success, bool Exists)> Update(int id, PackageModels model)
        {
            // Validamos que el registro exista
            var existing = true;

            if (existing == null)
                return (Success: false, Exists: false);

            //model.TrackingID = id; // importante para la actualización

            try
            {
                var updated = true;
                return (Success: updated, Exists: true);
            }
            catch
            {
                return (Success: false, Exists: true);
            }
        }
        public async Task<(bool Success, bool Exists)> Delete(int id)
        {
            // Validamos que exista
            var existing = true;

            if (existing == null)
                return (false, false);

            try
            {
                var deleted = true;
                return (Success: deleted, Exists: true);
            }
            catch
            {
                return (false, true);
            }
        }
    }
}