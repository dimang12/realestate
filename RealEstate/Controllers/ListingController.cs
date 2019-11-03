using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using RealEstate.Models;
using RealEstate.ViewModels;

namespace RealEstate.Controllers
{
    public class ListingController : Controller
    {
        private readonly IListingRepository _listingRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ListingController
        (
            IListingRepository listingRepository, 
            IHostingEnvironment hostingEnvironment
            )
        {
            this._listingRepository = listingRepository;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET
        public IActionResult Index()
        {
            List<Listing> listings = this._listingRepository.GetAllListings().ToList();
            ViewData["listings"] = listings;
            return View();
        }
        
        [HttpPost]
        public IActionResult AddListing(ListingCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var uniqueFileName = this.ProcessUploadFile(model);
                Listing listing = new Listing
                {
                    Address = model.Address,
                    Company = model.Company,
                    Image = uniqueFileName,
                    Price = model.Price
                };
                this._listingRepository.Add(listing);
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpGet]
        public ViewResult EditListing(int id)
        {

            Listing listing = this._listingRepository.GetListing(id);
            ListingEditViewModel listingEditViewModel = new ListingEditViewModel
            {
                ListingId = listing.ListingId,
                Address = listing.Address,
                Company = listing.Company,
                ExitingImagePath = listing.Image,
                Price = listing.Price
            };
            ViewData["listingId"] = id;
            return View(listingEditViewModel);
        }

        [HttpPost]
        public IActionResult EditListing(ListingEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Listing listing = this._listingRepository.GetListing(model.ListingId);
                listing.Address = model.Address;
                listing.Company = model.Company;
                listing.Price = model.Price;

                if (model.Image != null)
                {
                    if (model.ExitingImagePath != null)
                    {
                        string imagePath = Path.Combine(this._hostingEnvironment.WebRootPath, "/img/thumb", model.ExitingImagePath);
                        System.IO.File.Delete(imagePath);
                    }
                    var uniqueFileName = ProcessUploadFile(model);
                    listing.Image = uniqueFileName;
                }
                
                this._listingRepository.Update(listing);
                return RedirectToAction("index");
            }

            return View();
        }

        private string ProcessUploadFile(ListingCreateViewModel model)
        {
            string uniqueFileName = "";
            if (model.Image != null)
            {
                var uploadFolder = Path.Combine(this._hostingEnvironment.WebRootPath + "/img/thumb");
                uniqueFileName = Guid.NewGuid().ToString() + model.Image.FileName;
                var filePath = Path.Combine(uploadFolder, uniqueFileName);
                model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            return uniqueFileName;
        }
    }
}