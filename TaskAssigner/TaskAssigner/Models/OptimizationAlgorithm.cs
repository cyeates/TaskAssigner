using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskAssigner.Domain;
using TaskAssigner.Models.Repositories;

namespace TaskAssigner.Models
{
    /// <summary>
    /// An Optimization Algorithm is an algorithm that finds the best tickets for each developer based on the developer's preferences and tags indicated in each ticket.
    /// </summary>
    public abstract class OptimizationAlgorithm
    {
        public OptimizationAlgorithm(IDeveloperRepository developerRepository, ITicketRepository ticketRepository)
        {
            Developers = developerRepository.GetDevelopers();
            Tickets = ticketRepository.GetTickets();
            CostCalculator = new Cost(Developers, Tickets);
            Domain = GetDomain();
            
        }

        //used for unit testing
        public OptimizationAlgorithm()
        {
            
        }

        

        protected List<Developer> Developers { get; set; }
        protected List<Ticket> Tickets { get;  set; }
        protected Cost CostCalculator { get;  set; }

        /// <summary>
        /// Domain is a list that represents the ticket list.  Each value in the list is pair of integers that represent the minimum and maximum possible values in the solution.
        /// For example, [[0, 3], [0, 3], [0, 3], [0, 3]] represents four tickets.  If there are four developers, each minimum value is 0 (the first developer in the developers list).  The maximum value
        /// is 3 (the last developer in the developers list)
        /// </summary>
        protected List<List<int>> Domain { get; private set; }
        
        
        private List<List<int>> GetDomain()
        {
            var domain = new List<List<int>>();
            for (int i = 0; i < Tickets.Count; i++)
            {
                domain.Add(new List<int> { 0, Developers.Count });

            }

            return domain;
        }

        public abstract List<int> GetSolution();


    }
}