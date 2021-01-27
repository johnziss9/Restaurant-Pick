using System.Collections.Generic;
using Restaurant_Pick.Models;

namespace Restaurant_Pick.Services.RestaurantService
{
    public interface IRestaurantService
    {
         List<Restaurant> GetAllRestaurants();
         Restaurant GetRestaurantById(int id);
         List<Restaurant> AddRestaurant(Restaurant newRestaurant);
    }
}