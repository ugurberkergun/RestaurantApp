using RestaurantApp.Core.Utilities.Results;
using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Business.Abstract
{
    public interface IFoodCategoryService
    {
        ResponseModel<List<FoodCategory>> GetCategoryList();
    }
}
