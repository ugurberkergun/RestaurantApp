using Microsoft.EntityFrameworkCore;
using RestaurantApp.Core.DAL;
using RestaurantApp.Core.Entities;
using RestaurantApp.DAL.Concreate.EntityFramework.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Concreate.EntityFramework.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, IEntity, new()
    {
        public readonly AppDbContext _appDbContext;
        public readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _dbSet.AsNoTracking().AsQueryable() : _dbSet.Where(filter).AsQueryable();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
