using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Business.Abstract;
using RestaurantApp.DAL.Abstract.Repositories;

namespace RestaurantApp.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoodCategoryController : CustomBaseController
    {
        private readonly IFoodCategoryService _foodCategoryService;

        public FoodCategoryController(IFoodCategoryService foodCategoryService)
        {
            _foodCategoryService = foodCategoryService;
        }
        [HttpGet]
        public IActionResult GetFoodCategoryList()
        {
            return ActionResultInstance(_foodCategoryService.GetCategoryList());
        }
    }
}
