using BlazorTickets.Domain.Entities;

namespace BlazorTickets.Domain.Contracts
{
    public interface ITicketTypeRepository : IRepository<int, TicketType>
    {
    }
}
