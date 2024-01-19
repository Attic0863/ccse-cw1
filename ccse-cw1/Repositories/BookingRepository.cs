﻿using ccse_cw1.Controllers;
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
            if (hotel != null)
            {
                var hotelRooms = hotel.Rooms;

                foreach (var room in hotelRooms)
                {
                    if (room.RoomType == roomtype && room.IsAvailable(startDate, endDate))
                    {
                        AvailableRooms.Add(room);
                    }
                }
            }

            return AvailableRooms;
        }

        public async Task<Booking> CreateBooking(DateTime checkindate, DateTime checkoutdate, DateTime tourcheckin, string userId, int hotelid = 0, int tourid = 0, string roomtype = "")
        {
            var booking = new Booking
            {
                UserId = "-1",
                BookingDate = DateTime.Now,

            };

            // hotel booking
            if (hotelid != 0 && tourid ==  0)
            {
                booking = await CreateRoomBooking(userId, checkindate, checkoutdate, roomtype, hotelid);

                _context.Booking.Add(booking);
                foreach (var roombooking in booking.RoomBookings)
                {
                    _context.RoomBooking.Add(roombooking);
                }

            } // both booking
            else if (hotelid != 0 && tourid != 0)
            {
                booking = await CreateRoomBooking(userId, checkindate, checkoutdate, roomtype, hotelid);

                var tourbooking = await CreateTourBooking(userId, tourcheckin, tourid);
                tourbooking.TourBooking.Booking = booking;
                booking.TourBooking = tourbooking.TourBooking;

                booking.TotalPrice += tourbooking.TourBooking.Tour.Price;

                // now we do the discounts

                _context.Booking.Add(booking);
                foreach (var roombooking in booking.RoomBookings)
                {
                    _context.RoomBooking.Add(roombooking);
                }

            }
            else // tour only booking
            {
                booking = await CreateTourBooking(userId, tourcheckin, tourid);

                _context.Booking.Add(booking);
            }

            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> CreateTourBooking(string userId, DateTime checkin, int tourid)
        {
            var booking = new Booking
            {
                UserId = "-1",
                BookingDate = DateTime.Now,

            };

            var tour = await _context.Tours.FirstOrDefaultAsync(t => t.Id == tourid);
            if (tour != null)
            {
                if (tour.IsAvailable())
                {
                    booking.UserId = userId;

                    var tourbooking = new Tour_Booking
                    {
                        CheckInDate = checkin,
                        CheckOutDate = checkin.AddDays(tour.Duration),
                        Booking = booking,
                        Tour = tour,
                        TourId = tourid,
                    };

                    booking.TourBooking = tourbooking;

                    booking.TotalPrice += tour.Price;

                    return booking;
                }
            }
            return booking;
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
                if (selectedRoom != null)
                {
                    booking.UserId = userId;

                    var roombooking = new Room_Booking
                    {
                        CheckInDate = checkindate,
                        CheckOutDate = checkoutdate,
                        Booking = booking,
                        RoomId = selectedRoom.Id,
                    };

                    booking.RoomBookings.Add(roombooking);

                    booking.TotalPrice += selectedRoom.Price;

                    return booking;
                }
            }
            return booking;
        }
    }
}