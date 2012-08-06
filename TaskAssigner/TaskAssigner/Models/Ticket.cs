using System.Collections.Generic;

namespace TaskAssigner.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; } 

        public Ticket()
        {
            Tags = new List<string>();
        }
    }
}
