using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tracking.Domain.Entity;
using Tracking.Infrastructure.Config;

namespace Tracking.Infrastructure.Context
{
    public class TrackingDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<TrackingEntity> Tracking { get; set; }
        public TrackingDbContext(DbContextOptions<TrackingDbContext> options, IConfiguration configuration)
            : base( options )
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TrackingConfig());
        }

    
    }
}