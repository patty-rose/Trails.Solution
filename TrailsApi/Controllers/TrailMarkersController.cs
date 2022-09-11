using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrailsApi.Models;

//note that our API app routes don't return views like in a web application


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

    // GET api/trailMarkers -- Our GET route needs to return an ActionResult of type <IEnumerable<TrailMarker>>. In our web applications, we didn't need to specify a type because we were always returning a view.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrailMarker>>> Get()
    {
      return await _db.TrailMarkers.ToListAsync();
    }

    // POST api/trailMarkers -- Our POST route utilizes the function CreatedAtAction. This is so that it can end up returning the TrailMarker object to the user, as well as update the status code to 201, for "Created", rather than the default 200 OK.

    [HttpPost]
    public async Task<ActionResult<TrailMarker>> Post(TrailMarker trailMarker)
    {
      _db.TrailMarkers.Add(trailMarker);
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

    // [HttpPut("{id}")]
    // public async Task<IActionResult> Put(int id, TrailMarker trailMarker)
    // {
    //   if (id != trailMarker.TrailMarkerId)
    //   {
    //     return BadRequest();
    //   }

    //   _db.Entry(trailMarker).State = EntityState.Modified;

    //   try
    //   {
    //     await _db.SaveChangesAsync();
    //   }
    //   catch (DbUpdateConcurrencyException)
    //   {
    //     if (!TrailMarkerExists(id))
    //     {
    //       return NotFound();
    //     }
    //     else
    //     {
    //       throw;
    //     }
    //   }

    //   return NoContent();
    // }

    // private bool TrailMarkerExists(int id)
    // {
    //   return _db.TrailMarkers.Any(entry => entry.TrailMarkerId == id);
    // }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteTrailMarker(int id)
    // {
    //   var trailMarker = await _db.TrailMarkers.FindAsync(id);
    //   if (trailMarker == null)
    //   {
    //     return NotFound();
    //   }

    //   _db.TrailMarkers.Remove(trailMarker);
    //   await _db.SaveChangesAsync();

    //   return NoContent();
    // }

  }
}





// using TrailsApi.Models;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;
// using TrailsApi.Wrappers;
// using TrailsApi.Filter;
// using TrailsApi.Helpers;
// using TrailsApi.Services;


// namespace TrailsApi.Controllers
// {
//   [ApiController]
//   [Route("api/[controller]")]
//   public class TrailMarkersController : ControllerBase
//   {
//     private readonly ILogger<TrailMarkersController> _logger;
//     private readonly TrailsApiContext _db;
//     private readonly IUriService uriService;

//     public TrailMarkersController(ILogger<TrailMarkersController> logger, TrailsApiContext db, IUriService uriService)
//     {
//       _logger = logger;
//       _db = db;
//       this.uriService = uriService;
//     }

//     //CRUD methods
//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<TrailMarker>>> Get([FromQuery] PaginationFilter filter, string name)
//     {
//       var query = _db.TrailMarkers.AsQueryable();

//       if (name != null)
//       {
//         query = query.Where(entry => entry.Name == name);
//       }
      
//       //pagination and wrapper
//       var route = Request.Path.Value;
//       var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
//       var pagedData = await query
//         .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
//         .Take(validFilter.PageSize)
//         .ToListAsync();
//       var totalRecords = await query.CountAsync();
//       var pagedReponse = PaginationHelper.CreatePagedReponse<TrailMarker>(pagedData, validFilter, totalRecords, uriService, route);
//       return Ok(pagedReponse);
//     }

//     [HttpPost]
//     public async Task<ActionResult<TrailMarker>> Post(TrailMarker trailMarker)
//     {
//       _db.TrailMarkers.Add(trailMarker);
//       await _db.SaveChangesAsync();
      
//       return CreatedAtAction(nameof(GetTrailMarker), new { id = trailMarker.TrailMarkerId }, new Response<TrailMarker>(trailMarker));
//     }  

//     [HttpGet("{id}")]
//     public async Task<ActionResult<TrailMarker>> GetTrailMarker(int id)
//     {
//       var trailMarker = await _db.TrailMarkers.FindAsync(id);

//       if (trailMarker == null)
//       {
//           return NotFound();
//       }

//       return Ok(new Response<TrailMarker>(trailMarker));
//     }

//     [HttpPut("{id}")]
//     public async Task<IActionResult> Put(int id, TrailMarker trailMarker)
//     {
//       if (id != trailMarker.TrailMarkerId)
//       {
//         return BadRequest();
//       }

//       _db.Entry(trailMarker).State = EntityState.Modified;

//       try
//       {
//         await _db.SaveChangesAsync();
//       }
//       catch (DbUpdateConcurrencyException)
//       {
//         if (!TrailMarkerExists(id))
//         {
//           return NotFound();
//         }
//         else
//         {
//           throw;
//         }
//       }

//       return NoContent();
//     }

//     private bool TrailMarkerExists(int id)
//     {
//       return _db.TrailMarkers.Any(entry => entry.TrailMarkerId == id);
//     }

//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteTrailMarker(int id)
//     {
//       var trailMarker = await _db.TrailMarkers.FindAsync(id);
//       if (trailMarker == null)
//       {
//         return NotFound();
//       }

//       _db.TrailMarkers.Remove(trailMarker);
//       await _db.SaveChangesAsync();

//       return NoContent();
//     }

//   }
// }
