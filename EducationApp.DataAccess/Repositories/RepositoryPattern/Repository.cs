using EducationApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccess.Repositories.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Entity =>_context.Set<T>();
       
        public async Task AddAsync(T entity)
        {
           await Entity.AddAsync(entity);
        }

        public async Task AddRanceAsync(List<T> entities)
        {
            await Entity.AddRangeAsync(entities);
        }

        public async Task<T> FirstAsync()
        {
           T entity = await Entity.FirstOrDefaultAsync();
            return entity;
        }

        public async Task<T> FirstValAsync(Expression<Func<T, bool>> predicate)
        {
            T entity=await Entity.FirstOrDefaultAsync(predicate);
            return entity;
        }

        public IQueryable<T> GetAll()
        {
             IQueryable<T> entities=Entity.AsQueryable();

            return entities;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
             var res=Entity.Where(predicate);   
            return res;
        }

        public void Remove(T entity)
        {
            Entity.Remove(entity);
        }

        public async Task RemoveById(string Id)
        {
            T entity= await Entity.FindAsync(Guid.Parse(Id));
            Remove(entity);
        }

      
        public void Update(T entity)
        {
            Entity.Update(entity);  
        }
    }
}
