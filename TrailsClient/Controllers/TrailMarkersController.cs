using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrailsClient.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrailsClient.Controllers
{
  public class TrailMarkersController : Controller
  {
    private readonly ILogger<TrailMarkersController> _logger;

    public TrailMarkersController(ILogger<TrailMarkersController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      var allTrailMarkers = TrailMarker.GetTrailMarkers();
      return View(allTrailMarkers);
    }

    public IActionResult Details(int id)
    {
      var thisTrailMarker = TrailMarker.GetDetails(id);

      return View(thisTrailMarker);
    }

    public IActionResult Create()
    {
      ViewBag.TrailId = new SelectList (Trail.GetTrails(), "TrailId", "Name");
      return View();
    }

    [HttpPost]
    public IActionResult Create(TrailMarker trailMarker)
    {
      var thisTrail = Trail.GetDetails(trailMarker.TrailId);
      thisTrail.TrailMarkers.Add(trailMarker);
      TrailMarker.Post(trailMarker);
      return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
      var thisTrailMarker = TrailMarker.GetDetails(id);
      return View(thisTrailMarker);
    }

    [HttpPost]
    public IActionResult Edit(TrailMarker trailMarker)
    {
      TrailMarker.Put(trailMarker);
      return RedirectToAction("Details", new { id = trailMarker.TrailMarkerId });
    }

    public IActionResult Delete(int id)
      {
        var thisTrailMarker = TrailMarker.GetDetails(id);
        return View(thisTrailMarker);
      }

      [HttpPost, ActionName("Delete")]
      public IActionResult DeleteConfirmed(int id)
      {
        TrailMarker.Delete(id);
        return RedirectToAction("Index");
      }
  }
} 
