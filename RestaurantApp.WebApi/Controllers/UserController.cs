using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Business.Abstract;
using RestaurantApp.Entities.Dtos.Requests;

namespace RestaurantApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
        }
        [Authorize("Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return ActionResultInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }
        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUserRoles(string userName,string role)
        {
            return ActionResultInstance(await _userService.CreateUserRoles(userName,role));
        }
    }
}
