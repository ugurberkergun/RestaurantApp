using RestaurantApp.Core.Entities.Dtos;
using RestaurantApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Business.Abstract
{
    public interface IAuthService
    {
        Task<ResponseModel<TokenDto>> CreateToken(LoginDto loginDto);
        Task<ResponseModel<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<ResponseModel<NoDataDto>> RevokeRefreshToken(string refreshToken);
    }
}
