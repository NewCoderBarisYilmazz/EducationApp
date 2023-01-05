using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccess.Repositories.RepositoryPattern
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        DbSet<TEntity> Entity { get; }  
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task RemoveById(string Id);
        void Remove(TEntity entity);
        Task AddRanceAsync(List<TEntity> entities);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstValAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstAsync();

    }
}
