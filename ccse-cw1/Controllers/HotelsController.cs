using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ccse_cw1.Models;
using ccse_cw1.Services;

namespace ccse_cw1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HotelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            return Ok(await _context.Hotels.ToListAsync());
        }

        public class DateRangeModel
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        // POST: api/hotels/filterbydates
        [HttpPost("FilterByDates")]
        public async Task<ActionResult<IEnumerable<Hotel>>> PostFilterByDates([FromBody]DateRangeModel dateRange)
        {
            var availableHotels = new List<Hotel>();

            if (dateRange.StartDate >= dateRange.EndDate)
            {
                return BadRequest();
            }

            // use .include to ensure that the rooms navigator is included in the hotel object
            var hotels = await _context.Hotels.Include(h => h.Rooms).ToListAsync();

            foreach (var hotel in hotels)
            {
                var hotelRooms = hotel.Rooms;
                var availableRooms = hotelRooms.Where(r => r.IsAvailable(dateRange.StartDate, dateRange.EndDate)).ToList();
                if (availableRooms.Any())
                    availableHotels.Add(hotel);
            }

            if (availableHotels.Any())
            {
                // use a Data transfer object to anonymise (remove rooms)
                var response = availableHotels.Select(hotel => new
                {
                    hotel.Id,
                    hotel.Name,
                    hotel.Description,
                    hotel.Operator,
                    // Excluded the rooms
                }).ToList();
                return Ok(response);
            }
            else
                return NotFound();
        }
    }
}
