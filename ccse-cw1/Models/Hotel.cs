using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; } = "";

        public required string Operator { get; set; } = "";

        public required string Description { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();

    }
}
