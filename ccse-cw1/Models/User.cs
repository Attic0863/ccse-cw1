using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";
		public string Address { get; set; } = "";
		public DateTime RegistrationDate { get; set; }
	}
}
