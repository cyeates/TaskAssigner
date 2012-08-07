using System.Collections.Generic;

namespace TaskAssigner.Models
{
    public class Developer
    {
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
 
        public Developer()
        {
            Tags = new List<Tag>();
            Tickets = new List<Ticket>();
        }
    }
}
