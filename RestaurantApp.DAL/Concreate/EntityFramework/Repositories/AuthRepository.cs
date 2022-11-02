using RestaurantApp.Core.Entities.Models;
using RestaurantApp.DAL.Abstract.Repositories;
using RestaurantApp.DAL.Concreate.EntityFramework.DbContexts;
using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Concreate.EntityFramework.Repositories
{
    public class AuthRepository : GenericRepository<UserRefreshToken>, IAuthRepository
    {
        public AuthRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public IQueryable<UserRefreshToken> Where(Expression<Func<UserRefreshToken, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
