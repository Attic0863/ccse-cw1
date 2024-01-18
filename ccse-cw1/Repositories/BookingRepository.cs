using ccse_cw1.Controllers;
using ccse_cw1.Models;
using ccse_cw1.Services;
using Microsoft.EntityFrameworkCore;

namespace ccse_cw1.Repositories
{
    public class BookingRepository
    {
        private readonly AppDbContext _context;
        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Booking> GetBookingsFromUser(string userId)
        {
            var bookingsList = _context.Booking.Where(b => b.UserId == userId).ToList();

            return bookingsList;
        }

        private async Task<List<Room>> GetAvailableRoomsAsync(int hotelId, string roomtype, DateTime startDate, DateTime endDate, int amount = 1)
        {
            var AvailableRooms = new List<Room>();

            var hotel = await _context.Hotels.Include(h => h.Rooms).FirstOrDefaultAsync(h => h.Id == hotelId);
            var hotelRooms = hotel.Rooms;

            foreach (var room in hotelRooms)
            {
                if (room.RoomType == roomtype && room.IsAvailable(startDate, endDate))
                {
                    AvailableRooms.Add(room);
                }
            }

            return AvailableRooms;
        }



        public async Task<Booking> CreateRoomBooking(string userId, DateTime checkindate, DateTime checkoutdate, string roomtype, int hotelid)
        {
            var booking = new Booking
            {
                UserId = "-1",
                BookingDate = DateTime.Now,

            };

            var availableRooms = await GetAvailableRoomsAsync(hotelid, roomtype, checkindate, checkoutdate);
            if (availableRooms != null)
            {
                var selectedRoom = availableRooms.FirstOrDefault();
                booking.UserId = userId;

                var roombooking = new Room_Booking
                {
                    CheckInDate = checkindate,
                    CheckOutDate = checkoutdate,
                    Booking = booking,
                    RoomId = selectedRoom.Id,
                };

                booking.TotalPrice += selectedRoom.Price;

                _context.Booking.Add(booking);
                _context.RoomBooking.Add(roombooking);

                await _context.SaveChangesAsync();

                return booking;
            }

            return booking;

        }
           

        private async Task<List<Booking>> CreateMultipleBooking(string userId, List<Booking> bookings)
        {
            return new List<Booking>();
        }
    }
}