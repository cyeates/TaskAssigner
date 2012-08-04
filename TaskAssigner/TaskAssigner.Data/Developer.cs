using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskAssigner.Data
{
    public class Developer
    {
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; } 
    }
}
