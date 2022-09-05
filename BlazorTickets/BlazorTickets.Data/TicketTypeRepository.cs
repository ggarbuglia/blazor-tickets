using BlazorTickets.Domain.Contracts;
using BlazorTickets.Domain.Entities;

namespace BlazorTickets.Data
{
    public class TicketTypeRepository : Repository<int, TicketType>, ITicketTypeRepository
    {
        public TicketTypeRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
