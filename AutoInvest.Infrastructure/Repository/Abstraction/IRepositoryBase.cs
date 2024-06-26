﻿using System.Linq.Expressions;

namespace AutoInvest.Infrastructure.Repository.Abstraction
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression, bool trackChanges);
       void Update(T entity);
       void Delete(T entity);
       Task CreateAsync(T entity);
       Task SaveChangesAsync();
    }
}
