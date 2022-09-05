using BlazorTickets.Domain.Contracts;
using BlazorTickets.Domain.Entities;

namespace BlazorTickets.Data
{
    public class SystemGroupRepository : Repository<int, SystemGroup>, ISystemGroupRepository
    {
        public SystemGroupRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
