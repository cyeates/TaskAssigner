using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskAssigner.Data.Enums;

namespace TaskAssigner.Data
{
    public class Ticket
    {
        public int Estimate { get; set; }
        public Priority Priority { get; set; }
        public List<Tag> Tags { get; set; } 
    }
}
