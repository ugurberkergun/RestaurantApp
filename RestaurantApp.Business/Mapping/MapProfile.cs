using AutoMapper;
using RestaurantApp.Core.Entities.Dtos;
using RestaurantApp.Core.Entities.Models;
using RestaurantApp.Entities;
using RestaurantApp.Entities.Dtos.Requests;
using RestaurantApp.Entities.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Business.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Food,AddFoodRequestDto>().ReverseMap();
            CreateMap<Food,GetFoodDto>().ReverseMap();
            CreateMap<Food,DeleteFoodRequestDto>().ReverseMap();
            CreateMap<Food,UpdateFoodRequestDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<User,CreateUserDto>().ReverseMap();
        }
    }
}
