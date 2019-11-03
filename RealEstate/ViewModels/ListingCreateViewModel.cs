using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace RealEstate.ViewModels
{
    public class ListingCreateViewModel
    {
        [Required]
        public float Price { get; set; }
        [Required]
        [MaxLength(150,ErrorMessage = "Address can not exceed 150 characters")]
        public string Address { get; set; }
        [Required]
        public string Company { get; set; }
        public IFormFile Image { get; set; }
    }
}