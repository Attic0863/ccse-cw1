using ccse_cw1.Models;
using ccse_cw1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using System.Runtime.Intrinsics.X86;

namespace ccse_cw1.Pages
{
    [Authorize]
    public class DashboardModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserRepository _userRepository;

        public ICollection<Booking>? bookings;

        public DashboardModel(UserManager<ApplicationUser> userManager, UserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            // todo: get bookings from user or booking repo
        }

        public DateTime GenerateFirstCheckin(Booking booking)
        {
            // go through all types of bookings
            var roomBookingFirstCheckin = booking.RoomBookings?
                .OrderBy(rb => rb.CheckInDate)
                .FirstOrDefault()?.CheckInDate;

            var tourBookingFirstCheckin = booking.TourBooking?.CheckInDate;

            // combine both check ins and then find the frst
            var firstCheckinTime = new List<DateTime?> { roomBookingFirstCheckin, tourBookingFirstCheckin }
                .Where(checkInTime => checkInTime.HasValue)
                .Min();

            return firstCheckinTime ?? DateTime.Now;
        }

        public DateTime GenerateLastCheckout(Booking booking)
        {
            // go through all types of bookings
            var roomBookingLastCheckOut = booking.RoomBookings?
                .OrderByDescending(rb => rb.CheckOutDate)
                .FirstOrDefault()?.CheckOutDate;

            var tourBookingLastCheckOut = booking.TourBooking?.CheckOutDate;

            // combine both check outs and then find the latest
            var lastCheckOutTime = new List<DateTime?> { roomBookingLastCheckOut, tourBookingLastCheckOut }
                .Where(checkOutTime => checkOutTime.HasValue)
                .Max();

            return lastCheckOutTime ?? DateTime.Now;
        }

        public string GenerateHumanReadableTitle(Booking booking)
        {
            if (booking.RoomBookings != null && booking.RoomBookings.Any())
            {
                var firstRoomBooking = booking.RoomBookings.First();
                // use roomtype if only 1 booked
                if (booking.RoomBookings.Count == 1 && firstRoomBooking.Room != null)
                {
                    if (firstRoomBooking.Room.Hotel != null)
                        return $"{firstRoomBooking.Room.Hotel.Name} - {firstRoomBooking.Room.RoomType}";
                }
                else
                {
                    // if there is more than 1 room booked
                    if (booking.RoomBookings.Count > 1 && firstRoomBooking.Room != null)
                    {
                        if (firstRoomBooking.Room.Hotel != null)
                            return $"{firstRoomBooking.Room.Hotel.Name} - {booking.RoomBookings.Count} Rooms";
                    }
                }
            }
            else  // use tour booking
            {
                if (booking.TourBooking != null && (booking.RoomBookings == null || booking.RoomBookings.Count <= 0))
                {
                    return $"{booking.TourBooking.Tour.Name} - {booking.TourBooking.Tour.Duration}";
                }
            }

            // no human readable way
            return "Multiple Bookings";
        }
    }
}
