using BlazorTickets.Domain.Contracts;

namespace BlazorTickets.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DatabaseContext _context;

        public ISystemGroupRepository SystemGroup { get; private set; }
        public ISystemUserRepository SystemUser { get; private set; }
        public ITicketTypeRepository TicketType { get; private set; }
        public ITicketStatusRepository TicketStatus { get; private set; }
        public ITicketRepository Ticket { get; private set; }

        public UnitOfWork(DatabaseContext context)
        {
            _context     = context;
            SystemGroup  = new SystemGroupRepository(_context);
            SystemUser   = new SystemUserRepository(_context);
            TicketType   = new TicketTypeRepository(_context);
            TicketStatus = new TicketStatusRepository(_context);
            Ticket       = new TicketRepository(_context);
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
