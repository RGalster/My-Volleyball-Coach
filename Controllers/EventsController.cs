using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using YouthVolleyballHub.Data;
using YouthVolleyballHub.Models;
using YouthVolleyballHub.ViewModels;

namespace YouthVolleyballHub.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext context;

        public EventsController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Event> events = context.Events
                .Include(e => e.Category)
                .ToList();

            return View(events);
        }

        [Authorize]
        public IActionResult Add()
        {

            List<Organization> organizations = context.Organizations.ToList(); 
            List<EventCategory> categories = context.Categories.ToList();
            
            AddEventViewModel addEventViewModel = new AddEventViewModel(organizations, categories);

            
            

            return View(addEventViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory theCategory = context.Categories.Find(addEventViewModel.CategoryId);
                Organization theOrganization = context.Organizations.Find(addEventViewModel.OrganizationId);

                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Organization = theOrganization,
                    Category = theCategory
                };

                context.Events.Add(newEvent);
                context.SaveChanges();

                return Redirect("/Events");
            }

            return View(addEventViewModel);
        }

        [Authorize]
        public IActionResult Delete()
        {
            ViewBag.events = context.Events.ToList();

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }

            context.SaveChanges();

            return Redirect("/Events");
        }

        public IActionResult Detail(int id)
        {
            Event theEvent = context.Events
               .Include(e => e.Category)
               .Single(e => e.Id == id);

            List<EventTag> eventTags = context.EventTags
                .Where(et => et.EventId == id)
                .Include(et => et.Tag)
                .ToList();

            EventDetailViewModel viewModel = new EventDetailViewModel(theEvent, eventTags);
            return View(viewModel);

        }
    }
}
