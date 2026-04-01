using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondOfMany.Models;
using SecondOfMany.Models.ViewModel;
using System.Text.Json;

namespace SecondOfMany.Controllers {
    public class RegisterController : Controller {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/data/users.json");
       

        public IActionResult Index() { return View(); }

        [HttpPost]
        public IActionResult Index(RegisterViewModel vm) {
            if (!ModelState.IsValid)
                return View(vm);

            var users = ReadUsers();
            var Password = vm.Word;
            var user = new User(vm.userId, vm.fName, vm.lName, vm.Email, Password);

            var hasher = new PasswordHasher<User>();
            user.Password = hasher.HashPassword(user, user.Password);

            SaveUser(user, users);

            return RedirectToAction("ShowUsers");
        }

        public IActionResult ShowUsers() {
            var users = ReadUsers();
            return View(users);
        }

        private void SaveUser(User user, List<User> users) {
            users.Add(user);

            string json = JsonSerializer.Serialize(users,
                new JsonSerializerOptions { WriteIndented = true });

            System.IO.File.WriteAllText(_filePath, json);
        }

        private List<User> ReadUsers() {
            if (!System.IO.File.Exists(_filePath))
                return new List<User>();

            string json = System.IO.File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<User>();

            try {
                return JsonSerializer.Deserialize<List<User>>(json)
                       ?? new List<User>();
            } catch {
                return new List<User>();
            }
        }
    }
}