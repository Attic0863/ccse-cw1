using ccse_cw1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ccse_cw1.Services
{
	public class AppDbContext : IdentityDbContext<User>
	{
        public AppDbContext(DbContextOptions options) : base(options)
		{
            
        }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			var admin = new IdentityRole("admin")
			{
				NormalizedName = "admin"
			};

			var client = new IdentityRole("client")
			{
				NormalizedName = "client"
			};

			var seller = new IdentityRole("seller")
			{
				NormalizedName = "seller"
			};

			builder.Entity<IdentityRole>().HasData(admin, client, seller);
		}
	}
}
