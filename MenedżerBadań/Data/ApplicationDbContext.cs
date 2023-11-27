using HealthManager.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity>
    {
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<BodyEntity> BodyEntity { get; set; }
        public DbSet<DeviceEntity> DeviceEntity { get; set; }
        public DbSet<MeasurementEntity> MeasurementEntity { get; set; }
        public DbSet<ProfileEntity> ProfileEntity { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserEntity>().HasMany(n => n.Measurements).WithOne(n => n.User).HasForeignKey(n => n.UserId);
            builder.Entity<UserEntity>().HasOne(n => n.Profile).WithOne(n => n.User).HasForeignKey<ProfileEntity>(n => n.UserId);
        }

    }

}