using ccse_cw1.Models;

namespace ccse_cw1.Data
{
    public static class HotelSeedData
    {
        public static List<Hotel> Hotels { get; } = new List<Hotel>
        {
                new Hotel { Id = 1, Name = "Hilton London Hotel", Operator = "Hilton"},
                new Hotel { Id = 2, Name = "London Marriott Hotel", Operator = "Marriott"},
                new Hotel { Id = 3, Name = "Travelodge Brighton Seafront", Operator = "Travelodge"},
                new Hotel { Id = 4, Name = "Kings Hotel Brighton", Operator = "Kings Hotel"},
                new Hotel { Id = 5, Name = "Leonardo Hotel Brighton", Operator = "Leonardo"},
                new Hotel { Id = 6, Name = "Nevis Bank Inn, Fort William", Operator = "Nevis Bank Inn"}
        };

        // this might be a really hacky way of doing this 
        public static ICollection<Room> GenerateRooms()
        {
            var rooms = new List<Room>();

            var roomPrices = new List<List<int>>
            {
                new List<int> { 375, 775, 950 },
                new List<int> { 300, 500, 900 },
                new List<int> { 80, 120, 150 },
                new List<int> { 180, 400, 520 },
                new List<int> { 180, 400, 520 },
                new List<int> { 90, 100, 155 }
            };

            var roomTypes = new List<string> { "Single", "Double", "FamilySuite" };

            foreach (var roomPrice in roomPrices)
            {
                for (int i = 0; i < 20; i++)
                {
                    foreach (var roomType in roomTypes)
                    {
                        rooms.Add(new Room
                        {
                            HotelId = roomPrices.IndexOf(roomPrice) + 1,
                            RoomType = roomType,
                            Price = roomPrice[roomTypes.IndexOf(roomType)]
                        });
                    }
                }
            }

            return rooms;
        }
    }
}
