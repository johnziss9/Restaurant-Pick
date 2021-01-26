using Microsoft.AspNetCore.Mvc;
using Restaurant_Pick.Models;

namespace Restaurant_Pick.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : Controller
    {
        private static Restaurant restaurant = new Restaurant();

        public IActionResult Get()
        {
            return Ok(restaurant);
        }
    }
}