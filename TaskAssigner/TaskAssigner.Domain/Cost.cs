using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskAssigner.Data;

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

        public int Calculate(List<int> solution)
        {
            int cost = 0;
            for (int i = 0; i < _tickets.Count; i++)
            {
                var ticket = _tickets[i];
                int developerIndex = solution[i];
                var developer = _developers[developerIndex];

                if (!developer.Tags.Intersect(ticket.Tags).Any())
                {
                    cost += 1;
                }
            }

            return cost;


            ////gets sum of tickets that don't match up to developer's preferences
            //int cost = 0;
            //foreach (var developer in _developers)
            //{
            //    foreach(var ticket in developer.Tickets)
            //    {
            //        if (!developer.Tags.Intersect(ticket.Tags).Any())
            //        {
            //            cost += 1;
            //        }
            //    }
            //}

            //return cost;
        }
    }
}
