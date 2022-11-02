using RestaurantApp.Core.Entities.Dtos;
using RestaurantApp.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Core.Utilities.Security.Jwt
{
    public interface ITokenService
    {
        TokenDto CreateToken(User user);
    }
}
