using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
	public class ResetPasswordViewModel
	{
		[Required(ErrorMessage = "Password is required")]
		[StringLength(6, MinimumLength = 6, ErrorMessage = "MinimumLength is 6")]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$", ErrorMessage = "Password Must contain special character, capital character,smallcharacter character ")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Confirm Password is required")]
		[Compare(nameof(Password), ErrorMessage = "Confirm Password does not match password")]
		public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
