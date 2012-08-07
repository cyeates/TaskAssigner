using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskAssigner.Domain;
using TaskAssigner.Models;
using TaskAssigner.Models.Repositories;

namespace TaskAssigner.Controllers
{
    public class TicketAssignerController : Controller
    {
        private readonly DeveloperService _developerService;
        
        public TicketAssignerController( DeveloperService developerService)
        {
            _developerService = developerService;
            
        }

        public ActionResult Index()
        {
            
            var developers = _developerService.AssignTicketsToDevelopers();

            return null;

        }

    }
}
