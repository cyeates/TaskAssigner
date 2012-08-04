using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskAssigner.Data.Enums;

namespace TaskAssigner.Data
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Estimate { get; set; }
        public Priority Priority { get; set; }
        public List<string> Tags { get; set; } 

        public Ticket()
        {
            Tags = new List<string>();
        }
    }
}
