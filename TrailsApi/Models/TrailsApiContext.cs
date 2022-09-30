using Microsoft.EntityFrameworkCore;

namespace TrailsApi.Models
{
  public class TrailsApiContext : DbContext
  {
    public TrailsApiContext(DbContextOptions<TrailsApiContext> options) : base(options)
    {
    }

    public DbSet<Trail> Trails { get; set; }
    public DbSet<TrailMarker> TrailMarkers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

      builder.Entity<Trail>()
      .HasData(
        new Trail { TrailId = 1, Name = "Laurelhurst Stroll", Description = "stroll through Laurelhurst Park", Difficulty = "easy" }
      );

      builder.Entity<TrailMarker>()
      .HasData(
        new TrailMarker { TrailMarkerId = 1, TrailId = 1, Name = null, Longitude = -122.62578, Latitude = 45.52221, isTrailhead = false, isLandmark = false, Description = null },
        new TrailMarker { TrailMarkerId = 2, TrailId =1, Name = null, Longitude = -122.62634, Latitude = 45.52206, isTrailhead = false, isLandmark = false, Description = null },
        new TrailMarker { TrailMarkerId = 3, TrailId =1, Name = null, Longitude = -122.62942, Latitude = 45.52139, isTrailhead = false, isLandmark = false, Description = null },
        new TrailMarker { TrailMarkerId = 4, TrailId =1, Name = null, Longitude = -122.63052, Latitude = 45.5211, isTrailhead = false, isLandmark = false, Description = null },
        new TrailMarker { TrailMarkerId = 5, TrailId =1, Name = null, Longitude = -122.63084, Latitude = 45.52068, isTrailhead = false, isLandmark = false, Description = null },
        new TrailMarker { TrailMarkerId = 6, TrailId =1, Name = null, Longitude = -122.62761, Latitude = 45.52145, isTrailhead = false, isLandmark = false, Description = null },
        new TrailMarker { TrailMarkerId = 7, TrailId =1, Name = null, Longitude = -122.6259, Latitude = 45.52055, isTrailhead = false, isLandmark = false, Description = null },
        new TrailMarker { TrailMarkerId = 8, TrailId =1, Name = null, Longitude = -122.62324, Latitude = 45.52038, isTrailhead = false, isLandmark = false, Description = null }
      );
    }
  }
}