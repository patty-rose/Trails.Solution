using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrailsApi.Models;

namespace TrailsApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TrailMarkersController : ControllerBase
  {
    private readonly TrailsApiContext _db;

    public TrailMarkersController(TrailsApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrailMarker>>> Get()
    {
      return await _db.TrailMarkers.Include(trailMarker => trailMarker.Trail).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<TrailMarker>> Post(TrailMarker trailMarker)
    {
      Trail thisTrail = _db.Trails.FirstOrDefault(trail => trail.TrailId == trailMarker.TrailId);
      _db.TrailMarkers.Add(trailMarker);
      thisTrail.TrailMarkers.Add(trailMarker);
      trailMarker.Trail = thisTrail;

      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = trailMarker.TrailMarkerId }, trailMarker);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TrailMarker>> GetTrailMarker(int id)
    {
      var trailMarker = await _db.TrailMarkers.FindAsync(id);

      if (trailMarker == null)
      {
          return NotFound();
      }

      return trailMarker;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, TrailMarker trailMarker)
    {
      if (id != trailMarker.TrailMarkerId)
      {
        return BadRequest();
      }

      _db.Entry(trailMarker).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TrailMarkerExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool TrailMarkerExists(int id)
    {
      return _db.TrailMarkers.Any(entry => entry.TrailMarkerId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrailMarker(int id)
    {
      var trailMarker = await _db.TrailMarkers.FindAsync(id);
      if (trailMarker == null)
      {
        return NotFound();
      }

      _db.TrailMarkers.Remove(trailMarker);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}