using BlazorTickets.Domain.Entities;

namespace BlazorTickets.Domain.Contracts
{
    public interface ISystemUserRepository : IRepository<int, SystemUser>
    {
    }
}
