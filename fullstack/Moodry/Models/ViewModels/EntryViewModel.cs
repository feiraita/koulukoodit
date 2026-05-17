using System.ComponentModel.DataAnnotations;

namespace Moodry.Models.ViewModels {
    public class EntryViewModel {
        public MoodViewModel Mood { get; set; } = new();
        public NotesViewModel Notes { get; set; } = new();
        public ActivityViewModel Activity { get; set; } = new();

        [Required(ErrorMessage = "Date cannot be empty")]
        [Display(Name = "date")]
        public string date { get; set; }

        [Required(ErrorMessage = "Time cannot be empty")]
        [Display(Name = "time")]
        public string time { get; set; }

    }
}