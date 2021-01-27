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

        public async Task<ServiceResponse<List<Restaurant>>> AddRestaurant(Restaurant newRestaurant)
        {
            ServiceResponse<List<Restaurant>> serviceResponse = new ServiceResponse<List<Restaurant>>();
            restaurants.Add(newRestaurant);
            serviceResponse.Data = restaurants;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Restaurant>>> GetAllRestaurants()
        {
            ServiceResponse<List<Restaurant>> serviceResponse = new ServiceResponse<List<Restaurant>>();
            serviceResponse.Data = restaurants;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Restaurant>> GetRestaurantById(int id)
        {
            ServiceResponse<Restaurant> serviceResponse = new ServiceResponse<Restaurant>();
            serviceResponse.Data = restaurants.FirstOrDefault(c => c.Id == id);
            return serviceResponse;
        }
    }
}