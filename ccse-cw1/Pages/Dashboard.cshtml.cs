using ccse_cw1.Models;
using ccse_cw1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ccse_cw1.Pages
{
    [Authorize]
    public class DashboardModel : PageModel
    {
		private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserRepository _userRepository;
        private readonly BookingRepository _bookingRepository;

        public ICollection<Booking>? bookings;

		public DashboardModel(UserManager<ApplicationUser> userManager, UserRepository userRepository, BookingRepository bookingRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _bookingRepository = bookingRepository;
        }

        public void OnGet()
        {
            var task = _userManager.GetUserAsync(User);
            task.Wait();

            var user = task.Result;
            if (user != null)
                bookings = user.Bookings;
        }
    }
}
