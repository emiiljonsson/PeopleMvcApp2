using PeopleMvcApp.Models;

using System.ComponentModel.DataAnnotations;

namespace PeopleMvcApp.Models
{

public class EditPersonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
    }
}