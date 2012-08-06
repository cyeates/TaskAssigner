using System.Collections.Generic;

namespace TaskAssigner.Models
{
    public class Developer
    {
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IList<Ticket> Tickets { get; set; }
 
        public Developer()
        {
            Tags = new List<string>();
            Tickets = new List<Ticket>();
        }
    }
}
