using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        private IListingRepository _listingRepository;
        private readonly RealEstateDbContext _context;
        public HomeController(IListingRepository listingRepository, RealEstateDbContext context)
        {
            this._context = context;
            this._listingRepository = listingRepository;
        }
        public IActionResult Index()
        {
            List<Listing> listing = this._context.Listings.ToList();
            ViewData["listing"] = listing;
            return View();
        }

        public IActionResult Detail()
        {
            var listing = this._context.Listings.Find(1);
            ViewData["bg_color"] = "bg-light";
            ViewData["listing"] = listing;
            ViewData["pageTitle"] = "Detail";
            Console.WriteLine(listing);
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
