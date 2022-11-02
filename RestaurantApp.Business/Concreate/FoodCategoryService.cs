using RestaurantApp.Business.Abstract;
using RestaurantApp.Business.Contants;
using RestaurantApp.Core.DAL.UnitOfWork;
using RestaurantApp.Core.Utilities.Results;
using RestaurantApp.DAL.Abstract.Repositories;
using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Business.Concreate
{
    public class FoodCategoryService : IFoodCategoryService
    {
        private readonly IFoodCategoryRepository _foodCategoryRepository;
        public FoodCategoryService(IFoodCategoryRepository foodCategoryRepository, IUnitOfWork unitOfWork)
        {
            _foodCategoryRepository = foodCategoryRepository;
        }

        public ResponseModel<List<FoodCategory>> GetCategoryList()
        {
            try
            {
                var result = _foodCategoryRepository.GetList().AsQueryable().ToList();
                if (result.Count == 0)
                {
                    return new ResponseModel<List<FoodCategory>>() { HasError = true, Message = Messages.CategoryNotFound };
                }
                else
                {
                    return new ResponseModel<List<FoodCategory>>() { Data = result };
                }

            }
            catch (Exception ex)
            {
                return new ResponseModel<List<FoodCategory>>() { HasError = true,Message = ex.ToString() };
            };

        }

    }
}

