using FirstOfMany.Models;
using FirstOfMany.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstOfMany.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        public HomeController(ILogger<HomeController> logger) { _logger = logger; }

        [HttpGet]
        public IActionResult Index(string? sortBy, bool desc) {
            
            var motorcycles = new List<Motorcycle>();
            motorcycles.Add(new Motorcycle("Ducati", "Monster", 2016, "musta"));
            motorcycles.Add(new Motorcycle("Ducati", "Panigale V2", 2020, "punainen"));
            motorcycles.Add(new Motorcycle("Ducati", "1190", 2015, "musta"));
            motorcycles.Add(new Motorcycle("Yamaha", "XSR 900", 2014, "sininen"));

            if (sortBy != null) {
                if (sortBy.ToLower() == "vuosi") {
                    if (desc) { motorcycles = motorcycles.OrderByDescending(e => e.Vuosi).ToList();
                    } else { motorcycles = motorcycles.OrderBy(e => e.Vuosi).ToList(); }
                    

                } else if (sortBy.ToLower() == "merkki") {
                    if (desc) { motorcycles = motorcycles.OrderByDescending(e => e.Merkki).ToList();
                    } else { motorcycles = motorcycles.OrderBy(e => e.Merkki).ToList(); }
                    
                } else if (sortBy.ToLower() == "malli") {
                    if (desc) { motorcycles = motorcycles.OrderByDescending(e => e.Malli).ToList(); }
                    else { motorcycles = motorcycles.OrderBy(e => e.Malli).ToList(); }
                }
            }

            ViewData["desc"] = desc;
            var vm = new HomeIndexViewModel(motorcycles);
            return View(motorcycles);
        }

        [Route("/yhteystiedot")]
        public IActionResult Contact() { return View(); }

        public IActionResult Privacy() { return View(); }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
