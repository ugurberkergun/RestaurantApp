using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Core.Entities.Models
{
    public class User:IdentityUser
    {
        public string City { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
