using RestaurantApp.Core.Entities.Dtos;
using RestaurantApp.Core.Utilities.Results;
using RestaurantApp.Entities.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Business.Abstract
{
    public interface IUserService
    {
        Task<ResponseModel<UserDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<ResponseModel<UserDto>> GetUserByNameAsync(string userName);
        Task<ResponseModel<NoDataDto>> CreateUserRoles(string userEmail,string role);
    }
}
