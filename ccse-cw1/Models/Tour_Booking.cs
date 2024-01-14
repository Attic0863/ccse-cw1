using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
    public class Tour_Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public required Booking Booking { get; set; }

        [ForeignKey("Tour")]
        public int TourId { get; set; }
        public required Tour Tour { get; set; }
    }
}
