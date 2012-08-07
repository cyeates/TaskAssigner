using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskAssigner.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required]
        public string Description { get; set; }
        public virtual List<Tag> Tags { get; set; } 

        public Ticket()
        {
            Tags = new List<Tag>();
        }
    }
}
