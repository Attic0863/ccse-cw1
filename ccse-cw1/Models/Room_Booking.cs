using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
    public class Room_Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Booking")]
        public int BookingId { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }

        public required DateTime CheckInDate { get; set; }

        public required DateTime CheckOutDate { get; set; }

        public required Booking Booking { get; set; }

        public required Room Room { get; set; }

        public Discount? Discount { get; set; }
    }
}
