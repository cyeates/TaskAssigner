using System.Collections.Generic;

namespace TaskAssigner.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Description { get; set; }
        public virtual List<Tag> Tags { get; set; } 

        public Ticket()
        {
            Tags = new List<Tag>();
        }
    }
}
