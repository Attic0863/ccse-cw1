using ccse_cw1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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

			// Define identity roles

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

            // Define relationships between the different entities, many to one, etc
            builder.Entity<User>()
                .HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            builder.Entity<Booking>()
                .HasMany(b => b.RoomBookings)
                .WithOne(rb => rb.Booking)
                .HasForeignKey(rb => rb.BookingId);

         // TODO: possible add cascading deleting

        }
	}
}
