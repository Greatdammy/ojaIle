using System.ComponentModel.DataAnnotations;

namespace ojaile.client2.Model
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
        [MaxLength(50, ErrorMessage = "First name can not be more than 6 characters")]
        [MinLength(2, ErrorMessage = "First name can not be less than 2 characters")]
        public string? FirstName { get; set; }




        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
        [MaxLength(50, ErrorMessage = "Last name can not be more than 6 characters")]
        [MinLength(2, ErrorMessage = "Last name can not be less than 2 characters")]
        public string? LastName { get; set; }




        [Required(AllowEmptyStrings = false, ErrorMessage = "Username name is required")]
        [MaxLength(50, ErrorMessage = "Username can not be more than 6 characters")]
        [MinLength(2, ErrorMessage = "Username can not be less than 2 characters")]
        public string? UserName { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MaxLength(50, ErrorMessage = "Username can not be more than 50 characters")]
        [MinLength(6, ErrorMessage = "Password cannot be less than 6 character")]
        public string? Password { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [MaxLength(50, ErrorMessage = "Maximum length exceeded")]
        [EmailAddress]
        public string? Email { get; set; }



        public string? phoneNumber { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirm password must be the same")]
        public string? ConfirmPassword { get; set; }
    }
}