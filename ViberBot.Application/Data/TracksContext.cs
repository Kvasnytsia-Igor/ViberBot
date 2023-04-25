using Application.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public class TracksContext : DbContext
    {
        public TracksContext(DbContextOptions<TracksContext> options) : base(options) { }
        public DbSet<TrackLocation> TrackLocations => Set<TrackLocation>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackLocation>(
                dob =>
                {
                    dob.ToTable("TrackLocation");
                    dob.Property(o => o.Id).HasColumnName("id").HasColumnType("int");
                    dob.Property(o => o.IMEI).HasColumnName("IMEI").HasColumnType("varchar(50)");
                    dob.Property(o => o.Latitude).HasColumnName("latitude").HasColumnType("decimal(12,9)");
                    dob.Property(o => o.Longitude).HasColumnName("longitude").HasColumnType("decimal(12,9)");
                    dob.Property(o => o.DateTrack).HasColumnName("date_track").HasColumnType("datetime");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
