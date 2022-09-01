using BlazorTickets.Contracts;
using BlazorTickets.Entities;

namespace BlazorTickets.Data
{
    public class TicketTypeRepository : Repository<TicketType>, ITicketTypeRepository
    {
        public TicketTypeRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
