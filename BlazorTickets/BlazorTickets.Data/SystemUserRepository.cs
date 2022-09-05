using BlazorTickets.Domain.Contracts;
using BlazorTickets.Domain.Entities;

namespace BlazorTickets.Data
{
    public class SystemUserRepository : Repository<int, SystemUser>, ISystemUserRepository
    {
        public SystemUserRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
