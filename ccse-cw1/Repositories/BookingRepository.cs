using ccse_cw1.Services;

namespace ccse_cw1.Repositories
{
    public class BookingRepository
    {
        private readonly AppDbContext _context;
        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

    }
}
