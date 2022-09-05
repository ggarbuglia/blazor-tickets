using BlazorTickets.Domain.Entities;

namespace BlazorTickets.Domain.Contracts
{
    public interface ITicketStatusRepository : IRepository<int, TicketStatus>
    {
    }
}
