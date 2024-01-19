using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required double Amount { get; set; }

        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public virtual Booking? Booking { get; set; } // navigator

    }
}
