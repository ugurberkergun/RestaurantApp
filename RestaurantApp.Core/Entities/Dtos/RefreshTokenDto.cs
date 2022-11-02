using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Core.Entities.Dtos
{
    public class RefreshTokenDto:IDto
    {
        public string Token { get; set; }
    }
}
