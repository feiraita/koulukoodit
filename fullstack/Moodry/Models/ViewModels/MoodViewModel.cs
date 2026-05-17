using System.ComponentModel.DataAnnotations;

namespace Moodry.Models.ViewModels {
    public class MoodViewModel {
        [Required(ErrorMessage = "Please select a mood")]
        [Display(Name = "Mood")]
        public string mood { get; set; } = "";

        [Display(Name = "Describe your mood")]
        public string description { get; set; } = "";

        public MoodViewModel() {
            description = "";
            mood = "";
        }
    }
}