﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskAssigner.Models;

namespace TaskAssigner.Domain
{
    public class Cost
    {
        private readonly IList<Developer> _developers;
        private readonly IList<Ticket> _tickets;
       
        public Cost(IList<Developer> developers, IList<Ticket> tickets)
        {
            _developers = developers;
            _tickets = tickets;
           
        }

        /// <summary>
        /// Calculates the cost of the proposed solution.  Lower costs are better.
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        public int Calculate(List<int> solution)
        {
            int cost = 0;
           
            for (int i = 0; i < solution.Count; i++)
            {
                var ticket = _tickets[i];
                int developerIndex = solution[i];
                var developer = _developers[developerIndex];
                
                //increase cost if developer isn't assigned any interesting tickets
                var developerTags = developer.Tags.Select(t => t.Name).ToArray();
                var ticketTags = ticket.Tags.Select(t => t.Name).ToArray();
                if (!developerTags.Intersect(ticketTags).Any())
                {
                    cost += 1;
                }
                
            }
            
            return cost;
            
        }
    }
}
