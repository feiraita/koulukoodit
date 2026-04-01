using Microsoft.AspNetCore.Mvc;
using SecondOfMany.Models.ViewModel;
using System.Diagnostics;

namespace SecondOfMany.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
