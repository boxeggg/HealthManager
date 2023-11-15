using HealthManager.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MenedżerBadań.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<BodyEntity> BodyEntity { get; set; }
        public DbSet<DeviceEntity> DeviceEntity { get; set; }
        public DbSet<MeasurementEntity> MeasurementEntity { get; set; }
        public DbSet<MeasurementTypeEntity> MeasurementTypeEntity { get; set; }
        public DbSet<ProfileEntity> ProfileEntity { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }

}