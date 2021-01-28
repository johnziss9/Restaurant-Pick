using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant_Pick.DTOs.Restaurant;
using Restaurant_Pick.Models;

namespace Restaurant_Pick.Services.RestaurantService
{
    public interface IRestaurantService
    {
         Task<ServiceResponse<List<GetRestaurantDTO>>> GetAllRestaurants();
         Task<ServiceResponse<GetRestaurantDTO>> GetRestaurantById(int id);
         Task<ServiceResponse<List<GetRestaurantDTO>>> AddRestaurant(AddRestaurantDTO newRestaurant);
    }
}