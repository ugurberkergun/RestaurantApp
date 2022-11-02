using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Core.Utilities.Results
{
    public class ResponseModel<T> where T : class
    {
        public bool HasError { get; set; } = false;
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
