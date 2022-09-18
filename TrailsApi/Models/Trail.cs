using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TrailsApi.Models;

namespace TrailsApi.Models
{
  public class Trail
  {
    public int TrailId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Difficulty { get; set; }

    public virtual ICollection<TrailMarker> TrailMarkers { get; set; }

    public Trail()
      {
        this.TrailMarkers = new HashSet<TrailMarker>();
      }
  }
}