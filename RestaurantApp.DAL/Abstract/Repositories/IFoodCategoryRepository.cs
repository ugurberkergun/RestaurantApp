using RestaurantApp.Core.DAL;
using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Abstract.Repositories
{
    public interface IFoodCategoryRepository : IGenericRepository<FoodCategory>
    {
    }
}
