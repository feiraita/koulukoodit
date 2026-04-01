using Microsoft.AspNetCore.Mvc;

namespace FirstOfMany.Controllers
{
    public class TestiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
