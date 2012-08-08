using System.Collections.Generic;

namespace TaskAssigner.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public ICollection<Developer> Developers { get; set; }
        public ICollection<Ticket> Tickets { get; set; } 

    }

}
