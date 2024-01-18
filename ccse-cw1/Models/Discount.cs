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
        public int? RoomBookingId { get; set; }
        public virtual Room_Booking? RoomBooking { get; set; } // navigator

        [ForeignKey("Tour_Booking")]
        public int? TourBookingId { get; set; }
        public virtual Tour_Booking? TourBooking { get; set; } // navigator
    }
}
