using Package.Domain.Entity;
using Package.Domain.Interfaces;
using Package.Infrastructure.Context;

namespace Package.Infrastructure.Repository
{
    public class PackageRepository : IPackageRepository
    {
        private readonly PackageDbContext? _db;

        public PackageRepository(PackageDbContext db)
        { 
             _db   = db;
        }
        public async Task<string> CreatePackage( PackageEntity datos)
        {
            try
            {
                var result = _db.Package.Add(datos);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Que paos aqui", e);
            }

            return "Registrado";
        }
    }
}
