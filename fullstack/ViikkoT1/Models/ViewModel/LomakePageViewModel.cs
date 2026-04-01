using System.ComponentModel.DataAnnotations;

namespace ViikkoT1.Models.ViewModel {
    public class LomakePageViewModel {

        [Required]
        [Display(Name = "Most favorite number")]
        public int first { get; set; }

        [Required]
        [Display(Name = "Least favorite number", Prompt = "1")]
        public int second { get; set; }

        public List<Answer> Answers { get; set; } = new();
    }
}
