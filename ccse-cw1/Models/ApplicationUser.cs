using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
	public class ApplicationUser : IdentityUser // Id and other fields are inherited from IdentityUser
    {
        public required string FirstName { get; set; } = "";

        public required string LastName { get; set; } = "";

        public required string Address { get; set; } = "";

        public required string PassportNo { get; set; } = "";

        public string CustomerNo { get; set; } = "";
        public DateTime RegistrationDate { get; set; }
		public virtual ICollection<Booking>? Bookings { get; set; }
	}
}
