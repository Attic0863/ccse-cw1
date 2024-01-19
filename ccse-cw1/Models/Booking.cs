using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccse_cw1.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // autogenerate ids
        public int Id { get; set; }

        public DateTime BookingDate { get; set; }

        public bool Confirmed { get; set; }

        public bool Cancelled { get; set; }

        [ForeignKey("User")]
        public required string UserId { get; set; }

        public virtual ApplicationUser? User { get; set; } // navigator

        public virtual ICollection<Room_Booking> RoomBookings { get; set; } = new List<Room_Booking>(); // navigator

        [ForeignKey("Tour_Booking")]
        public int? TourBookingId { get; set; }
        public virtual Tour_Booking? TourBooking { get; set; } // navigator

        public int TotalPrice { get; set; }

    }
}
