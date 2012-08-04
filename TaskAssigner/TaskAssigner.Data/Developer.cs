using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskAssigner.Data
{
    public class Developer
    {
        public IEnumerable<string> Tags { get; set; }
        public IList<Ticket> Tickets { get; set; }
 
        public Developer()
        {
            Tags = new List<string>();
            Tickets = new List<Ticket>();
        }
    }
}
