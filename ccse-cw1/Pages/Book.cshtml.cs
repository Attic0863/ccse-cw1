using ccse_cw1.Models;
using ccse_cw1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Pages
{
    [Authorize]
    public class BookModel : PageModel
    {
        private readonly UserRepository _userRepository;
        private readonly BookingRepository _bookingRepository;
        private readonly HotelRepository _hotelRepository;

        public List<Hotel> hotels { get; set; }

        public ICollection<Room_Booking>? userroomBookings { get; set; }
        public Tour_Booking? usertourBooking { get; set; }

        public BookModel(UserRepository userRepository, BookingRepository bookingRepository, HotelRepository hotelRepository)
        {
            _userRepository = userRepository;
            _bookingRepository = bookingRepository;
            _hotelRepository = hotelRepository;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public Booking booking { get; set; }
        }

        public async Task OnGetAsync()
        {
            hotels = await _hotelRepository.GetHotelsOrThrowAsync();

        }
    }
}
