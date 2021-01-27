using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Pick.Models;

namespace Restaurant_Pick.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : Controller
    {
        private static List<Restaurant> restaurants = new List<Restaurant>
        {
            new Restaurant(),
            new Restaurant { Id = 1, Name = "Busaba", Location = "Stratford"}
        };

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(restaurants.FirstOrDefault(c => c.Id == id));
        }

        [HttpPost]
        public IActionResult AddRestaurant(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            return Ok(restaurants);
        }
    }
}