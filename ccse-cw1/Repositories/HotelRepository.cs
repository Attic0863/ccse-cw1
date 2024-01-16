using ccse_cw1.Exceptions;
using ccse_cw1.Models;
using ccse_cw1.Services;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ccse_cw1.Repositories
{
    public class HotelRepository
    {
        private readonly AppDbContext _context;
        public HotelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetHotelsOrThrowAsync()
        {
            if (_context.Hotels == null || !_context.Hotels.Any())
            {
                throw new HotelsNotAvailableException();
            }

            return await _context.Hotels.ToListAsync();
        }

        public async Task<List<Hotel>> GetHotelsByDatesAsync(DateTime startDate, DateTime endDate)
        {
            var availableHotels = new List<Hotel>();

            foreach (var hotel in await _context.Hotels.ToListAsync())
            {
                var availableRooms = hotel.Rooms.Where(r => r.IsAvailable(startDate, endDate)).ToList();
                if (availableRooms.Any())
                    availableHotels.Add(hotel);
            }

            return availableHotels;
        }
    }
}
