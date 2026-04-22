using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Phase7.Models.ViewModels {
    public class IncomeViewModel {
        public ObjectId incomeID { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Amount")]
        public decimal amount { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [Required]
        [Display(Name = "Recurring")]
        public string recurring { get; set; }

        public List<SelectListItem> SavingGoalsList { get; set; } = new();
        public List<Income> Incomes { get; set; } = new();

    }
}