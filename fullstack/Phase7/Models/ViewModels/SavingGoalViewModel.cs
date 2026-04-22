using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Phase7.Models.ViewModels {
    public class SavingGoalViewModel {
        public ObjectId savingID { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Goal")]
        public int goal { get; set; }

        [Required]
        [Display(Name = "Recurring")]
        public bool? recurring { get; set; }

        [Display(Name = "Payments each month")]
        public int? payments { get; set; }

        [Display(Name = "Date")]
        public DateTime? date { get; set; }

        //When add to saving
        [Required(ErrorMessage = "Amount is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        [Display(Name = "Amount")]
        public decimal? amount { get; set; }

        public decimal? total { get; set; }

        public List<Income> Incomes { get; set; } = new();

        public List<SelectListItem> SavingGoalsList { get; set; } = new();
        public List<SavingGoal> SavingGoals { get; set; } = new();
    }
}