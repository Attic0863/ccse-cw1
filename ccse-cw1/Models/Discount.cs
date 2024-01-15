using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required int Amount { get; set; }

        [ForeignKey("Room_Booking")]
        public int RoomBookingId { get; set; }
        public Room_Booking? RoomBooking { get; set; }

        [ForeignKey("Tour_Booking")]
        public int TourBookingId { get; set; }
        public Tour_Booking? TourBooking { get; set; }

        public required Booking Booking { get; set; }
    }
}
