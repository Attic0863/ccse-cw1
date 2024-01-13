using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
