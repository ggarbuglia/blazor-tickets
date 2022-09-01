using BlazorTickets.Contracts;
using BlazorTickets.Entities;

namespace BlazorTickets.Data
{
    public class SystemGroupRepository : Repository<SystemGroup>, ISystemGroupRepository
    {
        public SystemGroupRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
