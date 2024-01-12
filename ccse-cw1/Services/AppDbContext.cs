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

			var customer = new IdentityRole("customer")
			{
				NormalizedName = "customer"
            };

			var manager = new IdentityRole("manager")
			{
				NormalizedName = "manager"
			};

			builder.Entity<IdentityRole>().HasData(admin, customer, manager);
		}
	}
}
