using System.ComponentModel.DataAnnotations;

namespace SecondOfMany.Models.ViewModel {
    public class RegisterViewModel {
        public int userId { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "First Name")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Name must have 2-10 characters.")]
        public string fName { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Last Name")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Name must have 2-10 characters.")]
        public string lName { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Email")]
        [EmailAddress]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Email must have 3-30 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Password must have 3-30 characters.")]
        public string Pass { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Password must have 3-30 characters.")]
        [Compare("Pass", ErrorMessage = "Passwords do not match")]
        public string Word { get; set; }

    }
}