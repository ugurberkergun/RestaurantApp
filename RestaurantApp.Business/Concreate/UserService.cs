using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RestaurantApp.Business.Abstract;
using RestaurantApp.Business.Contants;
using RestaurantApp.Core.Entities.Dtos;
using RestaurantApp.Core.Entities.Models;
using RestaurantApp.Core.Utilities.Results;
using RestaurantApp.Entities.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Business.Concreate
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<ResponseModel<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            var result = await _userManager.CreateAsync(user,createUserDto.Password);
            await CreateUserRoles(user.UserName, "Customer");
            if (!result.Succeeded)
            {
                var error = result.Errors.Select(x => x.Description).FirstOrDefault();
                return new ResponseModel<UserDto>() { HasError = true, Message = error };
            }
            return new ResponseModel<UserDto>() { Data = _mapper.Map<UserDto>(user) };
        }

        public async Task<ResponseModel<NoDataDto>> CreateUserRoles(string userName,string role)
        {
            if (!await _roleManager.RoleExistsAsync($"{role}"))
            {
                await _roleManager.CreateAsync(new() { Name = $"{role}" });
            }
            var user =await _userManager.FindByNameAsync(userName);
            await _userManager.AddToRoleAsync(user, $"{role}");

            return new ResponseModel<NoDataDto>() { Message = Messages.RoleCreatedSuccessfully };
            
        }

        public async Task<ResponseModel<UserDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return new ResponseModel<UserDto>() { HasError = true, Message = Messages.UserNameNotFound };
            }
            return new ResponseModel<UserDto> { Data = _mapper.Map<UserDto>(user) };
        }
    }
}
