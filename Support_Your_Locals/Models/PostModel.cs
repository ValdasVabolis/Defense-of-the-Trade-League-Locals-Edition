using System.ComponentModel.DataAnnotations;

namespace Support_Your_Locals.Models
{
    public class PostModel
    {
        [Required(ErrorMessage = "Enter title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Add description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Enter email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter business address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Select working hours")]
        public string TimeSheet { get; set; }
    }
}
