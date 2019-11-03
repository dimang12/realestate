using System.Collections;
using System.Collections.Generic;

namespace RealEstate.Models
{
    public interface IListingRepository
    {
        Listing GetListing(int listingId);
        IEnumerable<Listing> GetAllListings();
        Listing Add(Listing listing);
        Listing Update(Listing listingChanges);
        Listing Delete(int id);
    }
}