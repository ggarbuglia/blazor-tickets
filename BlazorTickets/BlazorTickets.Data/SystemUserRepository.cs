using BlazorTickets.Contracts;
using BlazorTickets.Entities;

namespace BlazorTickets.Data
{
    public class SystemUserRepository : Repository<SystemUser>, ISystemUserRepository
    {
        public SystemUserRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
