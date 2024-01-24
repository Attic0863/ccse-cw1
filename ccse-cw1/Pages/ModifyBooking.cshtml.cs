using ccse_cw1.Models;
using ccse_cw1.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Pages
{
    public class ModifyBookingModel : PageModel
    {
        public Booking? Booking { get; set; }

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly BookingRepository _bookingRepository;

        public ModifyBookingModel(UserManager<ApplicationUser> userManager, BookingRepository bookingRepository)
        {
            _userManager = userManager;
            _bookingRepository = bookingRepository;
        }

        [Required]
        [BindProperty]
        public required ModifyInput Input { get; set; }

        public class ModifyInput
        {
            public int BookingId { get; set; }

            public DateTime checkedin { get; set; }
            public DateTime checkedout { get; set; }
        }

        public IActionResult OnGet()
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string bookingId = Request.Query["bookingId"];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (bookingId != null)
            {
                Booking = _bookingRepository.GetBooking(Convert.ToInt32(bookingId));


                return Page();
            }
            else
            {
                return Redirect("/");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            OnGet();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Input.checkedout <= Input.checkedin)
            {
                return Page();
            }

            if (Booking != null)
            {
                var modifiedBooking = await _bookingRepository.ModifyHotelBooking(Input.BookingId, Input.checkedin, Input.checkedout);

                if (modifiedBooking.Id != -1)
                {
                    return RedirectToPage("/ModifySuccess");
                }
            }



            return RedirectToPage("/ModifyFail");
        }
    }
}
