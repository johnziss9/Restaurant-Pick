using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant_Pick.Models;

namespace Restaurant_Pick.Services.RestaurantService
{
    public interface IRestaurantService
    {
         Task<ServiceResponse<List<Restaurant>>> GetAllRestaurants();
         Task<ServiceResponse<Restaurant>> GetRestaurantById(int id);
         Task<ServiceResponse<List<Restaurant>>> AddRestaurant(Restaurant newRestaurant);
    }
}