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
        public string UserId { get; set; }

        public required User User { get; set; }

        public ICollection<Room_Booking>? RoomBookings { get; set; }

       // public Tour TourBooking { get; set; } TODO

        public int TotalPrice { get; set; }

    }
}
