using Microsoft.EntityFrameworkCore;

namespace TMManagerApi.Models
{
    public class SatelliteContext : DbContext
    {
        public SatelliteContext(DbContextOptions<SatelliteContext> options) : base (options)
        {
        }

        public DbSet<OnlineSatellite> Satellites { get; set; }
        public DbSet<JobResponse> JobResponses { get; set; }
        public DbSet<JobRequest> JobRequests { get; set; }

    }
}
