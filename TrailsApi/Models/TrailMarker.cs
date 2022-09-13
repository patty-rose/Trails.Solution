using System.ComponentModel.DataAnnotations;

namespace TrailsApi.Models
{
  public class TrailMarker
  {
    public int TrailMarkerId { get; set; }

    public string Name { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public bool isTrailhead { get; set; }

    public bool isLandmark { get; set; }

    public string Description { get; set; }
  }
}