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
            int cost = developers.Sum(developer => developer.Tickets.Count(ticket => !developer.Tags.Intersect(ticket.Tags).Any()));

            return cost;
        }
    }
}
