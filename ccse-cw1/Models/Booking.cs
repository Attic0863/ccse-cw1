using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccse_cw1.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public DateTime BookingDate { get; set; }

        public bool Confirmed { get; set; }

        public bool Cancelled { get; set; }

        [ForeignKey("User")]
        public required string UserId { get; set; }

        [ForeignKey("Tour")]
        public required string TourId { get; set; }

        public required ApplicationUser User { get; set; }

        public ICollection<Room_Booking>? RoomBookings { get; set; }

        public Tour_Booking? TourBooking { get; set; }

        public int TotalPrice { get; set; }

    }
}
