using ccse_cw1.Exceptions;
using ccse_cw1.Models;
using ccse_cw1.Services;
using Microsoft.EntityFrameworkCore;

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
    }
}
