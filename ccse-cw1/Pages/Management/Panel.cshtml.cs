using ccse_cw1.Models;
using ccse_cw1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ccse_cw1.Pages.Management
{
    [Authorize(Roles = "manager,admin")]
    public class ManagerDashboardModel : PageModel
    {
        public List<Tour>? Tours { get; set; }
        public List<Hotel>? HotelList { get; set; }
        public List<Booking>? Bookings { get; set; }


        private readonly BookingRepository _bookingRepository;

        public ManagerDashboardModel(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;

            Bookings = _bookingRepository.GetBookings();
            HotelList = _bookingRepository.GetHotels();
            Tours = _bookingRepository.GetTours();
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public required InputModel Input { get; set; }

        public class InputModel
        {
            public DateTime checkindate { get; set; }
            public DateTime checkoutdate { get; set; }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Page();
        }
    }
}
