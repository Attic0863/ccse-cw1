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

        public string Description { get; set; } = "";

        public required int Price { get; set; }

        public required int Duration { get; set; }

        public required int MaxSpaces { get; set; }

        public virtual ICollection<Tour_Booking> TourBookings { get; set; } = new List<Tour_Booking>();

        // calculate if a tour is available
        public bool IsAvailable()
        {
            if (TourBookings.Count >= MaxSpaces)
                return false;
            else
                return true;
        }

        public int AmountOfBookings(DateTime checkInDate, DateTime checkOutDate)
        {
            // we will use this to count how many bookings there are on this specified daterange
            var overlapcount = 0;

            // iterate through each booking
            foreach (var tourBooked in TourBookings)
            {
                bool isBeforeOrSameDay = checkOutDate <= tourBooked.CheckInDate;
                bool isAfterOrSameDay = checkInDate >= tourBooked.CheckOutDate;

                // check for overlapping bookings
                bool overlap = !(isBeforeOrSameDay || isAfterOrSameDay) || (checkInDate == tourBooked.CheckOutDate || (tourBooked.CheckInDate == checkOutDate));

                if (overlap)
                    overlapcount += 1;
            }

            return overlapcount;
        }
    }
}
