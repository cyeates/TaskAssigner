using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskAssigner.Domain;
using TaskAssigner.Models.Repositories;

namespace TaskAssigner.Models
{
    public class DeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly ITicketRepository _ticketRepository;

        public DeveloperService(IDeveloperRepository developerRepository, ITicketRepository ticketRepository)
        {
            _developerRepository = developerRepository;
            _ticketRepository = ticketRepository;
        }

        public List<Developer> AssignTicketsToDevelopers()
        {
            var developers = _developerRepository.GetDevelopers();
            RemoveExistingTicketsFromDevelopers(developers);

            var tickets = _ticketRepository.GetTickets();

            var costCalculator = new Cost(developers, tickets);
            var optimization = new RandomOptimize(developers, tickets, costCalculator);
            var solution = optimization.GetSolution();

           
            for(int ticketIndex = 0; ticketIndex < solution.Count; ticketIndex++)
            {
                var developerIndex = solution[ticketIndex];
                var developer = developers[developerIndex];
                var ticket = tickets[ticketIndex];

                developer.Tickets.Add(ticket);
               
                
            }

            _developerRepository.Save();

            return developers;
        }

        private void RemoveExistingTicketsFromDevelopers(IEnumerable<Developer> developers)
        {
            foreach(var developer in developers)
            {
                developer.Tickets.Clear();
            }
        }
    }
}