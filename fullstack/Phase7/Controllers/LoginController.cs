using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Phase7.Models;
using Phase7.Models.Manipulators;
using Phase7.Models.ViewModels;
using Phase7.Models.ViewModels.Auth;
using System.Security.Claims;

namespace Phase7.Controllers {
    public class LoginController : Controller {

        public IActionResult Index() {
            if (User.Identity != null && User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Pages");
            }

            return View(new AuthViewModel {
                Login = new LoginViewModel(),
                Register = new RegisterViewModel()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AuthViewModel vm) {
            ModelState.Remove("Login");
            ModelState.Remove("Login.username");
            ModelState.Remove("Login.password");

            if (!ModelState.IsValid)
                return View("Index", vm);

            var user = new User {
                username = vm.Register.username,
                balance = 0,
                categories = DatabaseManipulator.GetDefaultCategories(),
                savings = new List<SavingGoal>() 
            };

            var hasher = new PasswordHasher<User>();
            user.password = hasher.HashPassword(user, vm.Register.pass);

            DatabaseManipulator.SaveItem(user);

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.username.ToLower()) };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );

            return RedirectToAction("Index", "Pages");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthViewModel vm) {

            ModelState.Remove("Register");
            ModelState.Remove("Register.username");
            ModelState.Remove("Register.pass");
            ModelState.Remove("Register.word");

            if (!ModelState.IsValid)
                return View("Index", vm);

            var user = DatabaseManipulator.GetAll<User>()
                .FirstOrDefault(u => u.username == vm.Login.username);

            if (user == null) {
                ModelState.AddModelError("", "Invalid username or password");
                return View("Index", vm);
            }

            var hasher = new PasswordHasher<User>();

            var result = hasher.VerifyHashedPassword(
                user,
                user.password,
                vm.Login.password
            );

            if (result == PasswordVerificationResult.Failed) {
                ModelState.AddModelError("", "Invalid username or password");
                return View("Index", vm);
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.username.ToLower()) };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );

            return RedirectToAction("Index", "Pages");
        }

        [HttpPost]
        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied(string? ReturnUrl) {
            if (ReturnUrl != null) { Console.WriteLine("Käyttäjä yrittänyt kiellettyyn mestaan: " + ReturnUrl); }

            return View();
        }
    }
}