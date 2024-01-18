using ccse_cw1.Models;
using ccse_cw1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccse_cw1.Pages
{
    [Authorize]
    public class BookModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly BookingRepository _BookingRepository;
        public BookModel(UserManager<ApplicationUser> userManager, BookingRepository bookingRepository)
        {
            _userManager = userManager;
            _BookingRepository = bookingRepository;
        }

        [Required]
        [BindProperty]
        public required InputModel Input { get; set; }

        // define the model which will be used for data transfer
        public class InputModel
        {
            // tour variables
            public int TourId { get; set; } = 0;
            public DateTime TourStartDate { get; set; } = DateTime.MinValue;

            // hotel variables
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public int HotelId { get; set; } = 0;
            public string RoomType { get; set; } = "Single";
            public int Amount { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            
            if (user != null)
            {
                // TODO: being able to book multiple rooms
                var booking = await _BookingRepository.CreateBooking(Input.CheckInDate, Input.CheckOutDate, Input.TourStartDate, user.Id, Input.HotelId, Input.TourId, Input.RoomType);
                if (booking.UserId != "-1")
                {
                    return RedirectToPage("/BookingSuccess");
                }

            }

            return RedirectToPage("/BookingFail");
        }
    }
}
