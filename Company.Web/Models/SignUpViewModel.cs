using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]

        public string LastName { get; set; }
        [EmailAddress(ErrorMessage ="Invalid Format Email")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [StringLength(6, MinimumLength = 6,ErrorMessage = "MinimumLength is 6")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$",ErrorMessage = "Password Must contain special character, capital character,smallcharacter character ")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare(nameof(Password),ErrorMessage ="Confirm Password does not match password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Required to Agree")]
        public bool IsAgree { get; set; }
    }
}
