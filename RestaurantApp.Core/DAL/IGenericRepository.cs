using RestaurantApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Core.DAL
{
    public interface IGenericRepository<T> where T : class,IEntity,new()
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetList(Expression<Func<T,bool>>filter = null);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
