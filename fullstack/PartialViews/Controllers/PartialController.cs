using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PartialViews.Controllers {
    public class PartialController : Controller {
        public IActionResult Index(int number) {
            ViewData["number"] = number;
            return View();
        }
        public IActionResult _FirstPage(int number) {
            ViewData["number"] = number;
            return PartialView();
        }
        public IActionResult _SecondPage(int number) {
            ViewData["number"] = number;
            return PartialView();
        }
    }
}
