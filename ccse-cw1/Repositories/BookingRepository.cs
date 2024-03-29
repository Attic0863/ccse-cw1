﻿using ccse_cw1.Controllers;
using ccse_cw1.Models;
using ccse_cw1.Pages;
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

        public List<Booking> GetBookings()
        {
            var bookings = _context.Booking.ToList();

            return bookings;
        }
        public List<Hotel> GetHotels()
        {
            var hotels = _context.Hotels.ToList();

            return hotels;
        }

        public List<Tour> GetTours()
        {
            var tours = _context.Tours.ToList();

            return tours;
        }

        public Booking GetBooking(int bookingid)
        {
            var booking = _context.Booking.FirstOrDefault(b => b.Id == bookingid);

#pragma warning disable CS8603 // Possible null reference return.
            return booking;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Booking> ModifyHotelBooking(int bookingId, DateTime checkin, DateTime checkout)
        {
            var booking = GetBooking(bookingId);

            var firstbooking = booking.RoomBookings.FirstOrDefault();
            if (firstbooking == null || firstbooking.Room == null)
                return booking;

            if (firstbooking.Room.Hotel != null)
            {
                var availableRooms = await GetAvailableRoomsAsync(firstbooking.Room.Hotel.Id, firstbooking.Room.RoomType, checkin, checkout, booking.RoomBookings.Count);

                if (availableRooms.Count >= booking.RoomBookings.Count)
                {
                    foreach (var roombooking in booking.RoomBookings)
                    {
                        roombooking.CheckInDate = checkin;
                        roombooking.CheckOutDate = checkout;
                    }
                }

                _context.Entry(booking).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return booking;
            }

            booking.Id = -1;

            return booking;
        }


        public async Task<Booking> CancelBooking(int bookingId)
        {
            var booking = await _context.Booking.FirstOrDefaultAsync(b => b.Id == bookingId);

            if (booking != null)
            {
                booking.Cancelled = true;

                _context.Entry(booking).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

#pragma warning disable CS8603 // Possible null reference return.
            return booking;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Booking> ConfirmBooking(string userId, int bookingId)
        {
            var booking = await _context.Booking.FirstOrDefaultAsync(b => b.Id == bookingId);

            if (booking != null)
            {
                booking.Confirmed = true;

                _context.Entry(booking).State = EntityState.Modified;

                //if (booking.UserId == userId)
                //{
                //    booking.Confirmed = true;

                //    _context.Entry(booking).State = EntityState.Modified;
                //}
            }

            await _context.SaveChangesAsync();

#pragma warning disable CS8603 // Possible null reference return.
            return booking;
#pragma warning restore CS8603 // Possible null reference return.
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

        public async Task<Booking> CreateBooking(DateTime checkindate, DateTime checkoutdate, DateTime tourcheckin, string userId, int hotelid = 0, int tourid = 0, string roomtype = "", int amount = 1)
        {
            var booking = new Booking
            {
                UserId = "-1",
                BookingDate = DateTime.Now,

            };

            // hotel booking
            if (hotelid != 0 && tourid ==  0)
            {
                booking = await CreateRoomBooking(userId, checkindate, checkoutdate, roomtype, hotelid, amount);

                _context.Booking.Add(booking);
                foreach (var roombooking in booking.RoomBookings)
                {
                    _context.RoomBooking.Add(roombooking);
                }

            } // both booking
            else if (hotelid != 0 && tourid != 0)
            {
                booking = await CreateRoomBooking(userId, checkindate, checkoutdate, roomtype, hotelid, amount);

                var tourbooking = await CreateTourBooking(userId, tourcheckin, tourid);

                if (tourbooking.TourBooking != null)
                {
                    tourbooking.TourBooking.Booking = booking;
                    booking.TotalPrice += tourbooking.TourBooking.Tour.Price;
                }

                booking.TourBooking = tourbooking.TourBooking;

                // now we calculate the discounts
                // we will use the first room.
                var firstRoomBooking = booking.RoomBookings.FirstOrDefault();
                if (firstRoomBooking != null)
                {
                    var room = firstRoomBooking.Room;
                    if (room != null)
                    {
                        var discountValue = (double)0;
                        if (room.RoomType == "Single") // 10% discount
                        { 
                            discountValue = booking.TotalPrice * 0.1;
                        }
                        if (room.RoomType == "Double") // 20% discount
                        {
                            discountValue = booking.TotalPrice * 0.2;
                        }
                        if (room.RoomType == "FamilySuite") // 10% discount
                        {
                            discountValue = booking.TotalPrice * 0.4;
                        }

                        var newDiscount = new Discount
                        {
                            Amount = discountValue,
                            Booking = booking,
                        };
                        booking.TotalPrice -= discountValue;
                        booking.Discount = newDiscount;

                    }
                }

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

            if (booking.UserId != "-1")
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
        

        public async Task<Booking> CreateRoomBooking(string userId, DateTime checkindate, DateTime checkoutdate, string roomtype, int hotelid, int amount)
        {
            var booking = new Booking
            {
                UserId = "-1",
                BookingDate = DateTime.Now,

            };

            var availableRooms = await GetAvailableRoomsAsync(hotelid, roomtype, checkindate, checkoutdate);
            if (availableRooms != null)
            {
                if (availableRooms.Count < amount)
                {
                    return booking;
                }

                for (var x = 0; x < amount; x++)
                {
                    var selectedRoom = availableRooms[x];
                    if (selectedRoom != null)
                    {
                        booking.UserId = userId;

                        var roombooking = new Room_Booking
                        {
                            CheckInDate = checkindate,
                            CheckOutDate = checkoutdate,
                            Booking = booking,
                            RoomId = selectedRoom.Id,
                            Room = selectedRoom,
                        };

                        booking.RoomBookings.Add(roombooking);

                        booking.TotalPrice += selectedRoom.Price * (checkoutdate - checkindate).Days;
                    }
                }

                return booking;
            }
            return booking;
        }
    }
}