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
  public class TrailsController : ControllerBase
  {
    private readonly TrailsApiContext _db;

    public TrailsController(TrailsApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Trail>>> Get()
    {
      return await _db.Trails.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Trail>> Post(Trail trail)
    {
      _db.Trails.Add(trail);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = trail.TrailId }, trail);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Trail>> GetTrail(int id)
    {
      var trail = await _db.Trails.FindAsync(id);

      if (trail == null)
      {
          return NotFound();
      }

      return trail;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Trail trail)
    {
      if (id != trail.TrailId)
      {
        return BadRequest();
      }

      _db.Entry(trail).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TrailExists(id))
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

    private bool TrailExists(int id)
    {
      return _db.Trails.Any(entry => entry.TrailId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrail(int id)
    {
      var trail = await _db.Trails.FindAsync(id);
      if (trail == null)
      {
        return NotFound();
      }

      _db.Trails.Remove(trail);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}