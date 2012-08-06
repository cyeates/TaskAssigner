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

        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetTickets()
        {
            var tickets = new List<Ticket>
                              {
                                  new Ticket
                                      {
                                          Description = "this is a test."
                                      },
                                  new Ticket {Description = "this is another ticket."}
                              };

            var tags = new List<string> { "JavaScript", "C#", "asp.net-mvc", "entity-framework", "sql", "database", "jQuery" };

            return Json(new {Tickets = tickets, Tags = tags}, JsonRequestBehavior.AllowGet);

            //return Json(_ticketRepository.GetTickets(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Create(Ticket ticket)
        {
            _ticketRepository.Add(ticket);
            _ticketRepository.Save();
        }

        
    }
}
