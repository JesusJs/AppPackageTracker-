using Microsoft.EntityFrameworkCore;
using Package.Domain.Entity;
using Package.Infrastructure.Context;


namespace Package.Infrastructure.DataSender
{
    public class PackageSender
    {
        private readonly PackageDbContext _db;

        public PackageSender(PackageDbContext db)
        {
            _db = db;
        }

        public async Task SeedAsync()
        {
            if (await _db.Package.AnyAsync())
                return;

            var Package = new List<PackageEntity>();

            await _db.Package.AddRangeAsync(Package);
            await _db.SaveChangesAsync();
        }
    }
}
