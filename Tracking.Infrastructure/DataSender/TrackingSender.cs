using Microsoft.EntityFrameworkCore;
using Tracking.Domain.Entity;
using Tracking.Infrastructure.Context;


namespace Tracking.Infrastructure.DataSender
{
    public class TrackingSender
    {
        private readonly TrackingDbContext _db;

        public TrackingSender(TrackingDbContext db)
        {
            _db = db;
        }

        public async Task SeedAsync()
        {
            if (await _db.Tracking.AnyAsync())
                return;

            var Package = new List<TrackingEntity>();

            await _db.Tracking.AddRangeAsync(Package);
            await _db.SaveChangesAsync();
        }
    }
}
