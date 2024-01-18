using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccse_cw1.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // autogenerate ids
        public int Id { get; set; }

        public required string Name { get; set; } = "";

        public required string Operator { get; set; } = "";

        public string? Description { get; set; }

        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>(); // navigator

    }
}
