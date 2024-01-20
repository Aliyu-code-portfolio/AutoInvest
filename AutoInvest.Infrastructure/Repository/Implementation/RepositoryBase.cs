using AutoInvest.Infrastructure.Persistent;
using AutoInvest.Infrastructure.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Resources;

namespace AutoInvest.Infrastructure.Repository.Implementation
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            //await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            var result = trackChanges ? _context.Set<T>().AsTracking() : _context.Set<T>().AsNoTracking();
            return result;

        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            var result = trackChanges ? _context.Set<T>().Where(expression).AsTracking()
                : _context.Set<T>().Where(expression).AsNoTracking();
            return result;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
