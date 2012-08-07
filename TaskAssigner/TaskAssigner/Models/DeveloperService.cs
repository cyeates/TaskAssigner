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
        private List<Developer> _developers;

        public DeveloperService(IDeveloperRepository developerRepository, ITicketRepository ticketRepository, OptimizationAlgorithm optimization)
        {
            _developerRepository = developerRepository;
            _ticketRepository = ticketRepository;
            _optimization = optimization;
        }

        /// <summary>
        /// Assigns tickets to developers based on the developer's preferences and tags indicated in each ticket.
        /// </summary>
        /// <returns></returns>
        public List<Developer> AssignTicketsToDevelopers()
        {
            _developers = _developerRepository.GetDevelopers();
            RemoveExistingTicketsFromDevelopers(_developers);

            var tickets = _ticketRepository.GetTickets();
            
            var solution = _optimization.GetSolution();

            for(int ticketIndex = 0; ticketIndex < solution.Count; ticketIndex++)
            {
                var developer = GetDeveloper(solution, ticketIndex);
                var ticket = tickets[ticketIndex];
                developer.Tickets.Add(ticket);
            }

            _developerRepository.Save();

            return _developers;
        }

        private Developer GetDeveloper(List<int> solution, int ticketIndex)
        {
            var developerIndex = solution[ticketIndex];
            var developer = _developers[developerIndex];
            return developer;
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