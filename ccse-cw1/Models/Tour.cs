using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
    public class Tour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // autogenerate ids
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Operator { get; set; }

        public required int Description { get; set; }

        public required int Price { get; set; }

        public required int Duration { get; set; }

        public required int MaxSpaces { get; set; }

        public virtual  ICollection<Tour_Booking> TourBookings { get; set; } = new List<Tour_Booking>();

        // calculate if a tour is available
        public bool IsAvailable()
        { 
            if (TourBookings.Count >= MaxSpaces)
                return false;
            else
                return true;
        }
    }
}
