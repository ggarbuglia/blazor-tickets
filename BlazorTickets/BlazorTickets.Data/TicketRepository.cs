using BlazorTickets.Domain.Contracts;
using BlazorTickets.Domain.Entities;

namespace BlazorTickets.Data
{
    public class TicketRepository : Repository<long, Ticket>, ITicketRepository
    {
        public TicketRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
