using BlazorTickets.Entities;
using System.Linq.Expressions;

namespace BlazorTickets.Contracts
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T?> GetById(Guid id);
        Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate);

        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);

        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}