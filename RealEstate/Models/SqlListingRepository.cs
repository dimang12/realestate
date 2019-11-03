using System.Collections.Generic;
using System.Linq;

namespace RealEstate.Models
{
    public class SqlListingRepository: IListingRepository
    {
        private readonly RealEstateDbContext _context;

        public SqlListingRepository(RealEstateDbContext context)
        {
            this._context = context;
        }
        public Listing GetListing(int listingId)
        {
            Listing listing = this._context.Listings.Find(listingId);
            return listing;
        }

        public IEnumerable<Listing> GetAllListings()
        {
            return this._context.Listings;
        }


        public Listing Add(Listing listing)
        {
            this._context.Add(listing);
            this._context.SaveChanges();
            return listing;
        }

        public Listing Update(Listing listingChanges)
        {
            var listing = this._context.Listings.Attach(listingChanges);
            listing.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._context.SaveChanges();
            return listingChanges;
        }

        public Listing Delete(int id)
        {
            Listing listing = this._context.Listings.Find(id);
            if (listing != null)
            {
                this._context.Listings.Remove(listing);
                this._context.SaveChanges();
            }

            return listing;
        }
    }
}