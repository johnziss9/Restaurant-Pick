using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Pick.Models;
using Restaurant_Pick.Services.RestaurantService;

namespace Restaurant_Pick.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            this._restaurantService = restaurantService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(_restaurantService.GetAllRestaurants());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(_restaurantService.GetRestaurantById(id));
        }

        [HttpPost]
        public IActionResult AddRestaurant(Restaurant newRestaurant)
        {
            return Ok(_restaurantService.AddRestaurant(newRestaurant));
        }
    }
}