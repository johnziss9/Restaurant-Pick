using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Restaurant_Pick.DTOs.Restaurant;
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

        private readonly IMapper _mapper;

        public RestaurantService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetRestaurantDTO>>> AddRestaurant(AddRestaurantDTO newRestaurant)
        {
            ServiceResponse<List<GetRestaurantDTO>> serviceResponse = new ServiceResponse<List<GetRestaurantDTO>>();
            Restaurant restaurant = _mapper.Map<Restaurant>(newRestaurant);
            restaurant.Id = restaurants.Max(c => c.Id) + 1;
            restaurants.Add(restaurant);
            serviceResponse.Data = (restaurants.Select(c => _mapper.Map<GetRestaurantDTO>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRestaurantDTO>>> GetAllRestaurants()
        {
            ServiceResponse<List<GetRestaurantDTO>> serviceResponse = new ServiceResponse<List<GetRestaurantDTO>>();
            serviceResponse.Data = (restaurants.Select(c => _mapper.Map<GetRestaurantDTO>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRestaurantDTO>> GetRestaurantById(int id)
        {
            ServiceResponse<GetRestaurantDTO> serviceResponse = new ServiceResponse<GetRestaurantDTO>();
            serviceResponse.Data = _mapper.Map<GetRestaurantDTO>(restaurants.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRestaurantDTO>> UpdateRestaurant(UpdateRestaurantDTO updateRestaurant)
        {
            ServiceResponse<GetRestaurantDTO> serviceResponse = new ServiceResponse<GetRestaurantDTO>();
            
            try
            {
                Restaurant restaurant = restaurants.FirstOrDefault(c => c.Id == updateRestaurant.Id);
                restaurant.Name = updateRestaurant.Name;
                restaurant.Cuisine = updateRestaurant.Cuisine;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Visited = updateRestaurant.Visited;
                restaurant.Deleted = updateRestaurant.Deleted;

                serviceResponse.Data = _mapper.Map<GetRestaurantDTO>(restaurant);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }            

            return serviceResponse;
        }
    }
}