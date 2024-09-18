using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
	public class ForgetPasswordModel
	{
		[EmailAddress(ErrorMessage = "Invalid Format Email")]
		[Required(ErrorMessage = "Email is Required")]
		public string Email { get; set; }
	}
}
