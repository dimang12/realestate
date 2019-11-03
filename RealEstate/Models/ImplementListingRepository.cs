using System.Collections.Generic;
using System.Linq;

namespace RealEstate.Models
{
    public class ImplementListingRepository : IListingRepository
    {
        private List<Listing> _listings;

        public ImplementListingRepository()
        {
            this._listings = new List<Listing>()
            {
                new Listing() {ListingId = 1, Address = "8363 E12TH St, Oakland, CA", Company = "Golden Gate Sothoby Realty", Image = "thumb-003.jpg", Price = 449000},
                new Listing() {ListingId = 2, Address = "1166 California St, Crescent City, CA", Company = "Pinnacle RealState Properties", Image = "thumb-005.jpg", Price = 229000}
            };
        }
        public Listing GetListing(int listingId)
        {
            return _listings.FirstOrDefault(e => e.ListingId == listingId);
        }

        public IEnumerable<Listing> GetAllListings()
        {
             return this._listings;
        }

        public Listing Add(Listing listing)
        {
            listing.ListingId = this._listings.Max(e => e.ListingId) + 1;
            this._listings.Add(listing);
            return listing;
        }

        public Listing Update(Listing listingChange)
        {
            Listing listing = this._listings.FirstOrDefault(e => e.ListingId == listingChange.ListingId);
            if (listing != null)
            {
                listing.Company = listingChange.Company;
                listing.Address = listingChange.Address;
                listing.Price = listingChange.Price;
            }

            return listing;
        }

        public Listing Delete(int id)
        {
            Listing listing = this._listings.FirstOrDefault(e => e.ListingId == id);
            if (listing != null)
            {
                this._listings.Remove(listing);
            }
            return listing;
        }
    }
}