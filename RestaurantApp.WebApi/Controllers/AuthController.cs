using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Business.Abstract;
using RestaurantApp.Core.Entities.Dtos;

namespace RestaurantApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            return ActionResultInstance(await _authService.CreateToken(loginDto));
            //var result = await _authService.CreateToken(loginDto);
            //if (result.HasError)
            //{
            //    return BadRequest(result);
            //}
            //return Ok(result.Data);
        }
        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            return ActionResultInstance(await _authService.RevokeRefreshToken(refreshTokenDto.Token));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            return ActionResultInstance(await _authService.CreateTokenByRefreshToken(refreshTokenDto.Token));
        }

    }
}
