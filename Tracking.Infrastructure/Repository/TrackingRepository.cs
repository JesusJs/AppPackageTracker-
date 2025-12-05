using Tracking.Domain.Entity;
using Tracking.Domain.Interfaces;
using Tracking.Infrastructure.Context;

namespace Tracking.Infrastructure.Repository
{
    public class TrackingRepository : ITrackingRepository
    {
        private readonly TrackingDbContext? _db;

        public TrackingRepository(TrackingDbContext db)
        { 
             _db   = db;
        }
        public async Task<string> CreatePackage( TrackingEntity datos)
        {
            try
            {
                var result = _db.Tracking.Add(datos);
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
