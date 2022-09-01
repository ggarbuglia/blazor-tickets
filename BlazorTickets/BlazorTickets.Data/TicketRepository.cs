using BlazorTickets.Contracts;
using BlazorTickets.Entities;

namespace BlazorTickets.Data
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
