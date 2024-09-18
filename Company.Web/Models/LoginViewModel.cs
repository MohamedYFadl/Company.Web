﻿using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Email is Required")]
		[EmailAddress(ErrorMessage = "Invalid Format Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}