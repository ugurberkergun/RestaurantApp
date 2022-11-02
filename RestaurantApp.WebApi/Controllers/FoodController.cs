using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Business.Abstract;
using RestaurantApp.Entities;
using RestaurantApp.Entities.Dtos.Requests;

namespace RestaurantApp.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoodController : CustomBaseController
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> AddFood(AddFoodRequestDto food)
        {
            return ActionResultInstance(await _foodService.AddFood(food));

        }
        [HttpGet]
        public async Task<IActionResult> GetFoodById(int id)
        {
            return ActionResultInstance(await _foodService.GetFoodById(id));
        }
        [HttpGet]
        public IActionResult GetFoodListByCategoryId(int categoryId)
        {
            return ActionResultInstance(_foodService.GetFoodListByCategoryId(categoryId));
        }
        [HttpGet]
        public IActionResult GetFoodList()
        {
            return ActionResultInstance(_foodService.GetList());
        }
        [Authorize("Admin")]
        [HttpPut]
        public IActionResult UpdateFood(UpdateFoodRequestDto food)
        {
            return ActionResultInstance(_foodService.UpdateFood(food));
        }
        [Authorize("Admin")]
        [HttpPost]
        public IActionResult DeleteFood(DeleteFoodRequestDto food)
        {
            return ActionResultInstance(_foodService.RemoveFood(food));
        }
    }
}
