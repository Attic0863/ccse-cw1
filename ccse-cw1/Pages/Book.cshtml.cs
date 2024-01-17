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
            [Required(ErrorMessage = "A valid Checkin date is required")]
            public DateTime CheckInDate { get; set; }

            [Required(ErrorMessage = "A valid Checkout is required")]
            public DateTime CheckOutDate { get; set; }

            [Required(ErrorMessage = "HotelId is required")]
            public int HotelId { get; set; }

            [Required(ErrorMessage = "Please pick a type of room")]
            public string RoomType { get; set; }

            [Required(ErrorMessage = "Amount is required")]
            public int Amount { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);

            var booking = await _BookingRepository.CreateRoomBooking(user.Id, Input.CheckInDate, Input.CheckOutDate, Input.RoomType, Input.HotelId);
            if (booking.UserId == "-1")
            {

            }

            return RedirectToPage("/SuccessPage");

        }
    }
}
