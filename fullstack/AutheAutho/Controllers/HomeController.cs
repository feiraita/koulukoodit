using AutheAutho.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

//Voi myös tehdä oman controllerin kaikille rooleille [Authorize(Roles = "admin")]
// Redirect voi myös ohjata toiseen controlleriin RedirectToAction("Logout", "login")
namespace AutheAutho.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult AccessDenied(string? ReturnUrl) {
            if (ReturnUrl != null) { Console.WriteLine("Käyttäjä yrittänyt kiellettyyn mestaan: " + ReturnUrl); }

            return View();
        }

        //Estää sivulle pääsyn
        [Authorize(Policy ="NoAdminAccess")]
        public IActionResult Dashboard() {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Admin() {
            return View();
        }

        //ViewModeliin
        // Keksi, joten ei kaikkia tietoja tänne
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password) {
            //Ilmoita vaan että "käyttäjä tai salasana on väärä" ei suoraan että kumpi 
            if (password != "kissa123") {
                TempData["errors"] = "Salasana ei ole yhtään miau";

                return RedirectToAction("Index"); 
            }

            var claims = new List<Claim>{ new Claim(ClaimTypes.Name, username.ToLower()) };

            if (username.ToLower() == "admin") { claims.Add(new Claim(ClaimTypes.Role, "admin")); }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //Sessio
            var authProperties = new AuthenticationProperties {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                IsPersistent = true //Cookie säilyy taustalla
            };

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(claimsIdentity), 
                authProperties
            );
            
            return RedirectToAction("Index");
        }

        public IActionResult Logout() {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index");
        }
    }
}
