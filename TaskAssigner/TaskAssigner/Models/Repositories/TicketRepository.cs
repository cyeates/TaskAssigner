using System.Collections.Generic;
using System.Linq;

namespace TaskAssigner.Models.Repositories
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetTickets();
        void Add(Ticket ticket);
        void Save();
    }

    public class TicketRepository : ITicketRepository
    {
        private readonly TaskAssignerContext _context;

        public TicketRepository(TaskAssignerContext context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _context.Tickets.ToList();
        }

        public void Add(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
