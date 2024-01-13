using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
	public class ApplicationUser : IdentityUser // Id and other fields are inherited from IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        [Required]
        public string Address { get; set; } = "";

		[Required]
        public string PassportNo { get; set; } = "";

        public string CustomerNo { get; set; } = "";
        public DateTime RegistrationDate { get; set; }
		public ICollection<Booking>? Bookings { get; set; }
	}
}
