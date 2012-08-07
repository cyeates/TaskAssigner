using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        [HttpGet]
        public JsonResult GetTickets()
        {
            var tickets = _ticketRepository.GetTickets();

            var tags = _tagRepository.GetTags();
            return Json(new {Tickets = tickets.Select(t => new {Description = t.Description, Tags = t.Tags.Select(tag => tag.Name).ToList()}), Tags = tags.Select(t => t.Name).ToList()}, JsonRequestBehavior.AllowGet);

            
        }

        [HttpPost]
        public void Create(Ticket ticket)
        {
            _ticketRepository.Add(ticket);
            _ticketRepository.Save();
        }

        
    }
}
