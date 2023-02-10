using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SIS.Core.Interfaces;

namespace SIS.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool isTracking = false);
        Task<T?> FindByIdAsync(int id);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
        DbSet<T> Table { get; }
    }
}

