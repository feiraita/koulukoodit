using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Phase7.Models.ViewModels.Auth {
    public class LoginViewModel {
        public int userID { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}
