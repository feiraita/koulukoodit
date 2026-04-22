using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Phase7.Models.ViewModels.Auth {
    public class RegisterViewModel {
        public int userID { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Username")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "username must have 2-10 characters.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 7, ErrorMessage = "Password must have 7-30 characters.")]
        public string pass { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 7, ErrorMessage = "Password must have 7-30 characters.")]
        [Compare("pass", ErrorMessage = "Passwords do not match")]
        public string word { get; set; }

        public List<User> Users { get; set; } = new();
    }
}