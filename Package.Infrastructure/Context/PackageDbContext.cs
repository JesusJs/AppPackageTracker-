using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Package.Domain.Entity;
using Package.Infrastructure.Config;

namespace Package.Infrastructure.Context
{
    public class PackageDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<PackageEntity> Package { get; set; }
        public PackageDbContext(DbContextOptions<PackageDbContext> options, IConfiguration configuration)
            : base( options )
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PackageConfig());
        }

    
    }
}