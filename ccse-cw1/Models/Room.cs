using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // autogenerate ids
        public int Id { get; set; }

        public required string RoomType { get; set; }

        public int Price { get; set; }

        [ForeignKey("Room_Booking")]
        public int? RoomBookingId { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        public Hotel? Hotel { get; set; }

        public ICollection<Room_Booking> RoomBookings { get; set; } = new List<Room_Booking>(); // navigator

        public bool IsAvailable(DateTime checkInDate, DateTime checkOutDate)
        {
            // if there is no booking associated with the room then it has to be available
            if (RoomBookings.Count == 0)
                return true;

            // iterate through each booking for the room
            foreach (var roomBooked in RoomBookings)
            {
                bool isBeforeOrSameDay = checkOutDate <= roomBooked.CheckInDate;
                bool isAfterOrSameDay = checkInDate >= roomBooked.CheckOutDate;

                // check for overlapping bookings
                bool overlap = !(isBeforeOrSameDay || isAfterOrSameDay) || (checkInDate == roomBooked.CheckOutDate || (roomBooked.CheckInDate == checkOutDate));

                if (overlap)
                    return false;
            }

            // if didnt find overlap then assume room available
            return true;
        }
    }
}
