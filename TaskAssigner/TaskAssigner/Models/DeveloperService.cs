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
        private readonly OptimizationAlgorithm _optimization;

        public DeveloperService(IDeveloperRepository developerRepository, ITicketRepository ticketRepository, OptimizationAlgorithm optimization)
        {
            _developerRepository = developerRepository;
            _ticketRepository = ticketRepository;
            _optimization = optimization;
        }

        public List<Developer> AssignTicketsToDevelopers()
        {
            var developers = _developerRepository.GetDevelopers();
            RemoveExistingTicketsFromDevelopers(developers);

            var tickets = _ticketRepository.GetTickets();
            
            var solution = _optimization.GetSolution();

           
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