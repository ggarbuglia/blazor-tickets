using BlazorTickets.Domain.Contracts;
using BlazorTickets.Domain.Entities;

namespace BlazorTickets.Data
{
    public class TicketStatusRepository : Repository<int, TicketStatus>, ITicketStatusRepository
    {
        public TicketStatusRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
