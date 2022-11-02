using RestaurantApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Entities.Dtos.Requests
{
    public class AddFoodRequestDto:IDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string PhotoUrl { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
