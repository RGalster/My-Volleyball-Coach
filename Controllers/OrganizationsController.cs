using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using YouthVolleyballHub.Data;
using YouthVolleyballHub.Models;
using YouthVolleyballHub.ViewModels;

namespace YouthVolleyballHub.Controllers
{
    public class OrganizationsController : Controller
    {
        private ApplicationDbContext context;

        public OrganizationsController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Organization> organizations = context.Organizations.ToList();

            return View(organizations);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddOrganizationViewModel addOrganizationViewModel)
        {
            if (ModelState.IsValid)
            {

                Organization newOrganization = new Organization
                {
                    Name = addOrganizationViewModel.Name,
                    Description = addOrganizationViewModel.Description,
                    ContactEmail = addOrganizationViewModel.ContactEmail
                };

                context.Organizations.Add(newOrganization);
                context.SaveChanges();


                // not sure I want to redirect to this page
                return Redirect("/Organizations");
            }

            return View(addOrganizationViewModel);
        }
    }
}
