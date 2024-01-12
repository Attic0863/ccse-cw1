using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
	public class User : IdentityUser
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string FullName { get; set; }

		public string? Address { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string PhoneNo { get; set; }

		public string CustomerNo { get; set; }

		public string PassportNo { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime RegistrationDate { get; set; }
	}
}
