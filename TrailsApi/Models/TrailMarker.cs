using System.ComponentModel.DataAnnotations;

namespace TrailsApi.Models
{
  public class TrailMarker
  {
    public int TrailMarkerId { get; set; }

    public string Name { get; set; }

    public int Longitude { get; set; }

    public int Latitude { get; set; }

    public bool isTrailhead { get; set; }

    public bool isLandmark { get; set; }

    public string Description { get; set; }
  }
}