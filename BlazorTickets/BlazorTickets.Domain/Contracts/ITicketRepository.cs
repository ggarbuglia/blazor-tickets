using BlazorTickets.Domain.Entities;

namespace BlazorTickets.Domain.Contracts
{
    public interface ITicketRepository : IRepository<long, Ticket>
    {
    }
}
