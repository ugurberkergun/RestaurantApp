using Microsoft.EntityFrameworkCore;
using RestaurantApp.Core.DAL;
using RestaurantApp.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Abstract.Repositories
{
    public interface IAuthRepository:IGenericRepository<UserRefreshToken>
    {
        IQueryable<UserRefreshToken> Where(Expression<Func<UserRefreshToken, bool>> expression);
    }
}
