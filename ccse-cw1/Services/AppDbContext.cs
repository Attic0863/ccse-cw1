using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ccse_cw1.Services
{
	public class AppDbContext : IdentityDbContext
	{
        public AppDbContext(DbContextOptions options) : base(options)
		{
            
        }
    }
}
