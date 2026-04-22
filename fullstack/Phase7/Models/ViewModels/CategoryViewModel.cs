using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Phase7.Models.ViewModels {
    public class CategoryViewModel {
        public ObjectId categoryID { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Monthly limit")]
        public bool? monthlyLimit { get; set; }

        [Display(Name = "Amount")]
        public decimal? amount { get; set; }

        public decimal? total { get; set; }

        public List<Expense> Expenses { get; set; } = new();
        public List<SelectListItem> CategoriesList { get; set; } = new();
        public List<Category> Categories{ get; set; } = new();
    }
}