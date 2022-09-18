using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrailsClient.Models;

namespace TrailsClient.Controllers
{
  public class TrailsController : Controller
  {
    private readonly ILogger<TrailsController> _logger;

    public TrailsController(ILogger<TrailsController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      var allTrails = Trail.GetTrails();
      return View(allTrails);
    }

    public IActionResult Details(int id)
    {
      var thisTrail = Trail.GetDetails(id);

      return View(thisTrail);
    }
  }
}