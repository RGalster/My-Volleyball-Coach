using System.ComponentModel.DataAnnotations;

namespace YouthVolleyballHub.ViewModels
{
    public class AddOrganizationViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description too long!")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        public AddOrganizationViewModel()
        {
        }
    }
}
