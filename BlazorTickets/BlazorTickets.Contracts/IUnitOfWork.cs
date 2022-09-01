namespace BlazorTickets.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ISystemGroupRepository SystemGroup { get; }
        ISystemUserRepository SystemUser { get; }
        ITicketTypeRepository TicketType { get; }
        ITicketStatusRepository TicketStatus { get; }
        ITicketRepository Ticket { get; }
        Task<int> SaveAsync();
    }
}
