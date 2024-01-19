using ccse_cw1.Models;
using ccse_cw1.Repositories;
using ccse_cw1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ccse_cw1.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly BookingRepository _bookingRepository;

        public BookingsController(AppDbContext context, BookingRepository bookingRepository)
        {
            _context = context;
            _bookingRepository = bookingRepository;
        }

        public class BookingInput
        {
            public string UserId { get; set; } = "";
            public int BookingId { get; set; }

            public DateTime checkedin { get; set; }
            public DateTime checkedout { get; set; }

            public DateTime tourcheckin { get; set; }

            // implement payment details here if necessary
        }

        //[HttpPost("modify")]
        //public async Task<ActionResult> ModifyAsync([FromBody] BookingInput bookingInput)
        //{
        //}

        [HttpPost("cancel")]
        public async Task<ActionResult> CancelAsync([FromBody] BookingInput bookingInput)
        {
            // 
            if (bookingInput == null)
            {
                return BadRequest("");
            }

            var booking = await _bookingRepository.CancelBooking(bookingInput.BookingId);

            if (booking == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost("pay")]
        public async Task<ActionResult> PayAsync([FromBody]BookingInput bookingInput)
        {
            // make sure that if payment functionality is ncessary then update these methods as intended to include payment processing and such

            if (bookingInput == null)
            {
                return BadRequest("");
            }

            var booking = await _bookingRepository.ConfirmBooking(bookingInput.UserId, bookingInput.BookingId);

            if (booking == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
    }
}
