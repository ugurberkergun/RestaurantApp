using RestaurantApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Entities
{
    public class FoodCategory:IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
