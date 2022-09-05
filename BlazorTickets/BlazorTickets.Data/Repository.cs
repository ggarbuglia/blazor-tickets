using BlazorTickets.Domain.Contracts;
using BlazorTickets.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorTickets.Data
{
    public class Repository<IdT, T> : IRepository<IdT, T> where T : AuditableEntity<IdT>
    {
        protected DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<int> CountAll()
        {
            return await _context.Set<T>().AsNoTracking().CountAsync();
        }

        public async Task<T?> GetById(IdT id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().CountAsync(predicate);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
