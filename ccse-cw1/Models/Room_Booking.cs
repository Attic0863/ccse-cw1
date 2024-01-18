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

        // virtual navigators, they are virtual for lazy loading
        public virtual Booking? Booking { get; set; }

        public virtual Room? Room { get; set; }

        public virtual Discount? Discount { get; set; }
    }
}
