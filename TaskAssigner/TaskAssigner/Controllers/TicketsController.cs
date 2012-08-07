using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TaskAssigner.Models;
using TaskAssigner.Models.Repositories;

namespace TaskAssigner.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITagRepository _tagRepository;

        public TicketsController(ITicketRepository ticketRepository, ITagRepository tagRepository)
        {
            _ticketRepository = ticketRepository;
            _tagRepository = tagRepository;
        }

        public ActionResult Index()
        {
            var tickets = _ticketRepository.GetTickets();
            return View(tickets);
        }

        [HttpGet]
        public JsonResult GetTickets()
        {
            var tickets = _ticketRepository.GetTickets();

            var tags = _tagRepository.GetTags();
            return Json(new {Tickets = tickets.Select(t => new {Description = t.Description, Tags = t.Tags.Select(tag => tag.Name).ToList()}), Tags = tags.Select(t => t.Name).ToList()}, JsonRequestBehavior.AllowGet);

            
        }

        public ActionResult Create()
        {
            var ticket = new Ticket();
            return View(ticket);
        }

        [HttpPost]
        public ActionResult Create(Ticket ticket, string tagsString)
        {
            AddTagsToTicket(ticket, tagsString);
            if (ModelState.IsValid)
            {
                _ticketRepository.Add(ticket);
                _ticketRepository.Save();

                return RedirectToAction("Index");
            }

            return View(ticket);


        }
        
        private Ticket AddTagsToTicket(Ticket ticket, string tagsString)
        {
            var tagNames = Regex.Split(tagsString, ", ");
            foreach(string tagName in tagNames.Where(t => !String.IsNullOrEmpty(t)))
            {
                var tag = _tagRepository.GetByName(tagName);
                ticket.Tags.Add(tag);
            }
            return ticket;
        }

        
    }
}
