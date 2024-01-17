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
        public required int RoomId { get; set; }

        public required DateTime CheckInDate { get; set; }

        public required DateTime CheckOutDate { get; set; }

        // navigators
        public Booking? Booking { get; set; }

        public Room? Room { get; set; }

        public Discount? Discount { get; set; }
    }
}
