using Microsoft.EntityFrameworkCore;

namespace ccse_cw1.Services
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions options) : base(options)
		{
            
        }
    }
}
