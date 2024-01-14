using ccse_cw1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ccse_cw1.Services
{
	public class AppDbContext : IdentityDbContext<ApplicationUser>
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
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            builder.Entity<Booking>()
                .HasMany(b => b.RoomBookings)
                .WithOne(rb => rb.Booking)
                .HasForeignKey(rb => rb.BookingId);

            builder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Room_Booking>()
                .HasOne(rb => rb.Room)
                .WithMany(r => r.RoomBookings)
                .HasForeignKey(rb => rb.RoomId)
                .IsRequired();

            builder.Entity<Room_Booking>()
                .HasOne(rb => rb.Booking)
                .WithMany(b => b.RoomBookings)
                .HasForeignKey(rb => rb.BookingId)
                .IsRequired();

            builder.Entity<Tour>()
                .HasMany(t => t.TourBookings)
                .WithOne(tb => tb.Tour)
                .HasForeignKey(tb => tb.TourId);

            builder.Entity<Tour_Booking>()
                .HasOne(tb => tb.Tour)
                .WithMany(t => t.TourBookings)
                .HasForeignKey(tb => tb.TourId);
        }
	}
}
