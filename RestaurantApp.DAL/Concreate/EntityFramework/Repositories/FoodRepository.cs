using RestaurantApp.DAL.Abstract.Repositories;
using RestaurantApp.DAL.Concreate.EntityFramework.DbContexts;
using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Concreate.EntityFramework.Repositories
{
    public class FoodRepository:GenericRepository<Food>,IFoodRepository
    {
        public FoodRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
