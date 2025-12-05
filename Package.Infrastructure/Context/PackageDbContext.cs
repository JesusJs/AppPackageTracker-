using Microsoft.EntityFrameworkCore;
using Package.Domain.Entity;

namespace Package.Infrastructure.Context
{
    public class PackageDbContext : DbContext
    {
        public PackageDbContext(DbContextOptions<PackageDbContext> options )
            : base( options ) { }

        public DbSet<PackageEntity> Package { get; set; }
    }
}
