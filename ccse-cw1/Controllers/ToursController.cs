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
    public class ToursController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToursController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTours()
        {
            if (_context.Tours == null)
            {
                return NotFound();
            }
            return Ok(await _context.Tours.ToListAsync());
        }

        [HttpGet("availabletours")]
        public async Task<ActionResult<IEnumerable<Tour>>> GetAvailableTours()
        {
            var availableTours = new List<Tour>();

            foreach (var tour in await _context.Tours.ToListAsync())
            {
                if (tour.IsAvailable())
                    availableTours.Add(tour);
            }

            if (availableTours.Any())
            {
                // use a Data transfer object to anonymise
                var response = availableTours.Select(tour => new
                {
                    tour.Id,
                    tour.Name,
                    tour.Description,
                    tour.Duration,
                    tour.Price
                }).ToList();
                return Ok(response);
            }
            else
                return NotFound();
        }
    }
}
