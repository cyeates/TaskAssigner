using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskAssigner.Data;

namespace TaskAssigner.Domain
{
    public class Cost
    {

        public int Calculate(IEnumerable<Developer> developers, IEnumerable<Ticket> tickets)
        {

            //gets sum of tickets that don't match up to developer's preferences
            int cost = 0;
            foreach (var developer in developers)
            {
                foreach(var ticket in developer.Tickets)
                {
                    if (!developer.Tags.Intersect(ticket.Tags).Any())
                    {
                        cost += 1;
                    }
                }
            }

            return cost;
        }
    }
}
