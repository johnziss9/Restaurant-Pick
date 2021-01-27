using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant_Pick.Models;

namespace Restaurant_Pick.Services.RestaurantService
{
    public interface IRestaurantService
    {
         Task<List<Restaurant>> GetAllRestaurants();
         Task<Restaurant> GetRestaurantById(int id);
         Task<List<Restaurant>> AddRestaurant(Restaurant newRestaurant);
    }
}