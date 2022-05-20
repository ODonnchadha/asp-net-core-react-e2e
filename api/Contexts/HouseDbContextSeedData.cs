using Microsoft.EntityFrameworkCore;

namespace api.Contexts
{
    public static class HouseDbContextSeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Entities.House>().HasData(new List<Entities.House> 
            {
                new Entities.House 
                {
                    Id = 1,
                    Address = "100 Duluth Street, DULUTH, Minnesota",
                    Coutry = "US",
                    Description = "Acceptable house. Somewhat nifty.",
                    Price = 200000
                },
                new Entities.House
                {
                    Id = 2,
                    Address = "40 Superior Street, SUPERIOR, Wisconsin",
                    Coutry = "US",
                    Description = "Dog food. Unacceptable.",
                    Price = 400
                }
            });
        }
    }
}