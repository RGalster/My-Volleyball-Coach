using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YouthVolleyballHub.Models;

namespace YouthVolleyballHub.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description too long!")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Organization is required")]
        public int OrganizationId { get; set; }
        public List<SelectListItem> Organizations { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }
        public AddEventViewModel(List<Organization> organizations, List<EventCategory> categories)
        {
            Organizations = new List<SelectListItem>();
            foreach (var organization in organizations)
            {
                Organizations.Add(
                    new SelectListItem
                    {
                        Value = organization.Id.ToString(),
                        Text = organization.Name
                    }
                ); ;
            }

            Categories = new List<SelectListItem>();
            foreach (var category in categories)
            {
                Categories.Add(
                    new SelectListItem
                    {
                        Value = category.Id.ToString(),
                        Text = category.Name
                    }
                ); ;
            }
        }

        

        //public AddEventViewModel(List<EventCategory> categories)
        //{
        //    Categories = new List<SelectListItem>();

        //    foreach (var category in categories)
        //    {
        //        Categories.Add(
        //            new SelectListItem
        //            {
        //                Value = category.Id.ToString(),
        //                Text = category.Name
        //            }
        //        ); ;
        //    }
        //}

        public AddEventViewModel() 
        { 
        }
    }
}
