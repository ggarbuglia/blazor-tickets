using BlazorTickets.Contracts;
using BlazorTickets.Entities;

namespace BlazorTickets.Data
{
    public class TicketStatusRepository : Repository<TicketStatus>, ITicketStatusRepository
    {
        public TicketStatusRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
