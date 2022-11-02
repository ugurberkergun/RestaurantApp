using AutoMapper;
using RestaurantApp.Business.Abstract;
using RestaurantApp.Business.Contants;
using RestaurantApp.Core.DAL.UnitOfWork;
using RestaurantApp.Core.Utilities.Results;
using RestaurantApp.DAL.Abstract.Repositories;
using RestaurantApp.Entities;
using RestaurantApp.Entities.Dtos.Requests;
using RestaurantApp.Entities.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Business.Concreate
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FoodService(IFoodRepository foodRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseModel<NoDataDto>> AddFood(AddFoodRequestDto addedFood)
        {

            try
            {
                if (addedFood == null)
                {
                    return new ResponseModel<NoDataDto>() { HasError = true, Message = Messages.FoodIsNull };
                }
                else
                {
                    var food = _mapper.Map<Food>(addedFood);
                    await _foodRepository.AddAsync(food);
                    await _unitOfWork.CommitAsync();
                    return new ResponseModel<NoDataDto>() { Message = Messages.FoodAddedSuccess };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<NoDataDto>() { HasError = true, Message = ex.ToString() };
            }
        }

        public async Task<ResponseModel<GetFoodDto>> GetFoodById(int id)
        {
            try
            {
                var food = await _foodRepository.GetByIdAsync(id);
                if (food == null || food.IsDeleted)
                {
                    return new ResponseModel<GetFoodDto>() { HasError = true,Message=Messages.FoodNotFound };
                }
                else
                {
                    var getFoodDto = _mapper.Map<GetFoodDto>(food);
                    return new ResponseModel<GetFoodDto>() { Data = getFoodDto };
                }

            }
            catch (Exception ex)
            {
                return new ResponseModel<GetFoodDto>() { HasError = true, Message = ex.ToString() };
            }

        }

        public ResponseModel<List<GetFoodDto>> GetFoodListByCategoryId(int categoryId)
        {
            var foodlist = _foodRepository.GetList(l => l.CategoryId == categoryId && l.IsDeleted == false ).ToList();
            if (foodlist.Count < 1)
            {
                return new ResponseModel<List<GetFoodDto>> { HasError = true, Message = Messages.ThereIsNoFoodInThisCategory };
            }
            else
            {
                List<GetFoodDto> foodDtoList = new();
                foreach (var food in foodlist)
                {
                    var getFoodDto = _mapper.Map<GetFoodDto>(food);
                    foodDtoList.Add(getFoodDto);
                }
                return new ResponseModel<List<GetFoodDto>> { Data = foodDtoList };
            }
        }

        public ResponseModel<List<GetFoodDto>> GetList()
        {
            var foodlist = _foodRepository.GetList(l => l.IsDeleted == false).ToList();
            if (foodlist.Count < 1)
            {
                return new ResponseModel<List<GetFoodDto>> { HasError = true, Message = Messages.ThereIsNoFood };
            }
            else
            {
                List<GetFoodDto> foodDtoList = new();
                foreach (var food in foodlist)
                {
                    var getFoodDto = _mapper.Map<GetFoodDto>(food);

                    foodDtoList.Add(getFoodDto);
                }
                return new ResponseModel<List<GetFoodDto>> { Data = foodDtoList };
            }
        }

        public ResponseModel<NoDataDto> RemoveFood(DeleteFoodRequestDto deletedFood)
        {
            try
            {
                var food = _mapper.Map<Food>(deletedFood);
                _foodRepository.Update(food);
                _unitOfWork.Commit();
                return new ResponseModel<NoDataDto>() { Message = Messages.FoodDeletedSuccessfully };
            }
            catch (Exception ex)
            {

                return new ResponseModel<NoDataDto>() { HasError = true, Message = ex.ToString() };
            }
        }

        public ResponseModel<NoDataDto> UpdateFood(UpdateFoodRequestDto updatedFood)
        {
            try
            {
                var food = _mapper.Map<Food>(updatedFood);
                _foodRepository.Update(food);
                _unitOfWork.Commit();
                return new ResponseModel<NoDataDto>() { HasError = false, Message = Messages.FoodUpdatedSuccessfully};
            }
            catch (Exception ex)
            {
                return new ResponseModel<NoDataDto>() { HasError = true, Message = ex.ToString() };
            }
        }
    }
}
