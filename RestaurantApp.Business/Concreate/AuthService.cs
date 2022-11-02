using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using RestaurantApp.Business.Abstract;
using RestaurantApp.Business.Contants;
using RestaurantApp.Core.DAL.UnitOfWork;
using RestaurantApp.Core.Entities.Dtos;
using RestaurantApp.Core.Entities.Models;
using RestaurantApp.Core.Utilities.Results;
using RestaurantApp.Core.Utilities.Security.Jwt;
using RestaurantApp.DAL.Abstract.Repositories;
using System.Text;
using System.Text.Json;

namespace RestaurantApp.Business.Concreate
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthRepository _authRepository;
        public AuthService(IUnitOfWork unitOfWork, UserManager<User> userManager, ITokenService tokenService, IAuthRepository authRepository)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _tokenService = tokenService;
            _authRepository = authRepository;
        }

        public async Task<ResponseModel<TokenDto>> CreateToken(LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return new ResponseModel<TokenDto>() { HasError = true, Message = Messages.ErrorLogin }; 
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null)
                {
                    return new ResponseModel<TokenDto>() { HasError = true, Message = Messages.ErrorLogin };
                }
                if (!await _userManager.CheckPasswordAsync(user,loginDto.Password))
                {
                    return new ResponseModel<TokenDto>() { HasError = true, Message = Messages.ErrorLogin };
                }
                var token = _tokenService.CreateToken(user);
                var userRefreshToken = _authRepository.Where(x => x.UserId == user.Id).SingleOrDefault();
                if (userRefreshToken== null)
                {
                    await _authRepository.AddAsync(new UserRefreshToken { UserId = user.Id, RefreshToken = token.RefreshToken, Expiration = token.RefreshTokebExpiration });
                }
                else
                {
                    userRefreshToken.RefreshToken = token.RefreshToken;
                    userRefreshToken.Expiration = token.RefreshTokebExpiration;
                }
                await _unitOfWork.CommitAsync();
                return new ResponseModel<TokenDto>() { Data = token };
            }
        }

        public async Task<ResponseModel<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = _authRepository.Where(x => x.RefreshToken == refreshToken).SingleOrDefault();
            if (existRefreshToken == null)
            {
                return new ResponseModel<TokenDto>() { HasError = true, Message = Messages.RefreshTokenNotFound };
            }
            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if (user == null)
            {
                return new ResponseModel<TokenDto>() { HasError = true, Message = Messages.UserIdNotFoundForRefreshToken };
            }
            var tokenDto = _tokenService.CreateToken(user);
            existRefreshToken.RefreshToken = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokebExpiration;
            await _unitOfWork.CommitAsync();
            return new ResponseModel<TokenDto>() { Data = tokenDto };
        }

        public async Task<ResponseModel<NoDataDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = _authRepository.Where(x => x.RefreshToken == refreshToken).SingleOrDefault();
            if (existRefreshToken == null)
            {
                return new ResponseModel<NoDataDto>() { HasError = true, Message = Messages.RefreshTokenNotFound };
            }
            _authRepository.Delete(existRefreshToken);
            await _unitOfWork.CommitAsync();
            return new ResponseModel<NoDataDto>() { Message = Messages.TokenDeletedSuccesfully };
        }
    }
}
