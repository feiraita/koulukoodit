using System.ComponentModel.DataAnnotations;

namespace Moodry.Models.ViewModels {
    public class NotesViewModel {
        [Display(Name = "Anything to add?")]
        public string text { get; set; } = "";

        public NotesViewModel() { text = ""; }
    }
}