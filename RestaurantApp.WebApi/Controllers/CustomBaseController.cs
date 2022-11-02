using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Core.Utilities.Results;

namespace RestaurantApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(ResponseModel<T> response) where T : class
        {
            if (!response.HasError)
            {
                return new ObjectResult(response)
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new ObjectResult(response)
                {
                    StatusCode = 400
                };
            }

            
        }
    }
}
