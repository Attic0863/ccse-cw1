using ccse_cw1.Models;

namespace ccse_cw1.Data
{
    public class TourSeedData
    {
        public static List<Tour> Tours { get; } = new List<Tour>
        {
                new Tour { Id = 1, Name = "Real Britain", Duration = 6, MaxSpaces = 30, Price = 1200 },
                new Tour { Id = 2, Name = "Britain and Ireland Explorer", Duration = 16, MaxSpaces = 40, Price = 2000 },
                new Tour { Id = 3, Name = "Best of Britain", Duration = 12, MaxSpaces = 30, Price = 2900 },
        };
    }
}
