using BlazorCoreHybrid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlazorCoreHybrid.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Todo(int AutoLoad) {
            bool model = AutoLoad > 0;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
