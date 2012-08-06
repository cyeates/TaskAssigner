using System.Data.Entity;

namespace TaskAssigner.Models
{
    public class TaskAssignerContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Tag> Tags { get; set; }
        
    }
}
