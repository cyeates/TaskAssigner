using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskAssigner.Domain;

namespace TaskAssigner.Models
{
    public abstract class OptimizationAlgorithm
    {
       public OptimizationAlgorithm(List<Developer> developers, List<Ticket> tickets, Cost calculator)
        {
            Developers = developers;
            Tickets = tickets;
            CostCalculator = calculator;
            Domain= GetDomain();
        }

        

        protected List<Developer> Developers { get; set; }
        protected List<Ticket> Tickets { get;  set; }
        protected Cost CostCalculator { get;  set; }
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