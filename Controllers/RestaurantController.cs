using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Pick.DTOs.Restaurant;
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
        public async Task<IActionResult> Get()
        {
            return Ok(await _restaurantService.GetAllRestaurants());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _restaurantService.GetRestaurantById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurant(AddRestaurantDTO newRestaurant)
        {
            return Ok(await _restaurantService.AddRestaurant(newRestaurant));
        }
    }
}