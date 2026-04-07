using Microsoft.AspNetCore.Mvc;
using MongoDB_testi.Models;
using MongoDB_testi.Models.Manipulators;
using System.Diagnostics;

namespace MongoDB_testi.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            var autot = DatabaseManipulator.GetAll<Auto>();
            //var auto = new Auto() { merkki = "Toyota" };

            foreach(var auto in autot.Where(e => string.Where(auto.merkki).isEmpty()) {
                auto.merkki = "Ei määritelty";
                auto.Save();
            }

            return View();
            
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
