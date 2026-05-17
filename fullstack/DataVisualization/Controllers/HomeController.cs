using DataVisualisation.Models;
using DataVisualization.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataVisualisation.Controllers;

public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) {
        _logger = logger;
    }

    public IActionResult Index() {
        var OurData = StatsFactory.CreateData(
            new DateTime(2025, 1, 1),
            new DateTime(2025, 12, 31),
            5234
            );
        OurData = OurData.Where(e => e.Date.Month != 7).ToList();
        var vm = new StatsViewModel(OurData);
        return View(vm);
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}