using Microsoft.EntityFrameworkCore;

namespace RealEstate.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Listing>().HasData(
                new Listing
                {
                    ListingId = 2,
                    Address = "10 4TH St, San Francisco",
                    Company = "Golden RealEstate",
                    Image = "thumb-005",
                    Price = 599000
                }
            );
        }
    }
}