using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using ViikkoT1.Models;
using ViikkoT1.Models.ViewModel;

namespace ViikkoT1.Controllers {
    public class HomeController : Controller {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/data/answers.json");

        public IActionResult Index() {
            var vm = new LomakePageViewModel { Answers = ReadAnswers() };

            return View(vm);
        }
        public IActionResult _LomakePage() {
            var vm = new LomakePageViewModel { Answers = ReadAnswers() };

            return PartialView("_LomakePage", vm);
        }

        [HttpPost]
        public IActionResult _LomakePage(LomakePageViewModel vm) {
            if (!ModelState.IsValid) {
                vm.Answers = ReadAnswers();
                return PartialView("_LomakePage", vm);
            }

            var answers = ReadAnswers();
            var answer = new Answer(answers.Count + 1, vm.first, vm.second);

            SaveAnswer(answer, answers);

            return RedirectToAction("Index");
        }

        public IActionResult ShowAnswers() {
            var answers = ReadAnswers();
            return View(answers);
        }

        private void SaveAnswer(Answer answer, List<Answer> answers) {
            answers.Add(answer);

            string json = JsonSerializer.Serialize(answers,
                new JsonSerializerOptions { WriteIndented = true });

            System.IO.File.WriteAllText(_filePath, json);
        }

        private List<Answer> ReadAnswers() {
            if (!System.IO.File.Exists(_filePath)) { return new List<Answer>(); }

            string json = System.IO.File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json)) { return new List<Answer>(); }

            try {
                return JsonSerializer.Deserialize<List<Answer>>(json)
                       ?? new List<Answer>();
            } catch { return new List<Answer>();}
        }
    }
}