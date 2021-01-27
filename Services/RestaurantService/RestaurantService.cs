using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant_Pick.Models;

namespace Restaurant_Pick.Services.RestaurantService
{
    public class RestaurantService : IRestaurantService
    {
        private static List<Restaurant> restaurants = new List<Restaurant>
        {
            new Restaurant(),
            new Restaurant { Id = 1, Name = "Busaba", Location = "Stratford"}
        };

        public async Task<List<Restaurant>> AddRestaurant(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            return restaurants;
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            return restaurants;
        }

        public async Task<Restaurant> GetRestaurantById(int id)
        {
            return restaurants.FirstOrDefault(c => c.Id == id);
        }
    }
}