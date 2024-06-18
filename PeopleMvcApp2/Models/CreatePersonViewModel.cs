using System.ComponentModel.DataAnnotations;
using System;

namespace PeopleMvcApp.Models
{
    public class CreatePersonViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
    }
}
