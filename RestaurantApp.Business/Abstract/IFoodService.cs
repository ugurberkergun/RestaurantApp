using RestaurantApp.Core.Utilities.Results;
using RestaurantApp.Entities;
using RestaurantApp.Entities.Dtos.Requests;
using RestaurantApp.Entities.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Business.Abstract
{
    public interface IFoodService
    {
        Task<ResponseModel<GetFoodDto>> GetFoodById(int id);
        ResponseModel<List<GetFoodDto>> GetList();
        ResponseModel<List<GetFoodDto>> GetFoodListByCategoryId(int categoryId);
        Task<ResponseModel<NoDataDto>> AddFood(AddFoodRequestDto food);
        ResponseModel<NoDataDto> UpdateFood(UpdateFoodRequestDto food);
        ResponseModel<NoDataDto> RemoveFood(DeleteFoodRequestDto food);

    }
}
