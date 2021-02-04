using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant_Pick.Data;
using Restaurant_Pick.DTOs.Restaurant;
using Restaurant_Pick.Models;

namespace Restaurant_Pick.Services.RestaurantService
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public RestaurantService(IMapper mapper, DataContext context)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetRestaurantDTO>>> AddRestaurant(AddRestaurantDTO newRestaurant)
        {
            ServiceResponse<List<GetRestaurantDTO>> serviceResponse = new ServiceResponse<List<GetRestaurantDTO>>();
            Restaurant restaurant = _mapper.Map<Restaurant>(newRestaurant);
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Restaurants.Select(c => _mapper.Map<GetRestaurantDTO>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRestaurantDTO>>> GetAllRestaurants()
        {
            ServiceResponse<List<GetRestaurantDTO>> serviceResponse = new ServiceResponse<List<GetRestaurantDTO>>();
            List<Restaurant> dbRestaurants = await _context.Restaurants.ToListAsync();
            serviceResponse.Data = (dbRestaurants.Select(c => _mapper.Map<GetRestaurantDTO>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRestaurantDTO>> GetRestaurantById(int id)
        {
            ServiceResponse<GetRestaurantDTO> serviceResponse = new ServiceResponse<GetRestaurantDTO>();
            Restaurant dbRestaurant = await _context.Restaurants.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetRestaurantDTO>(dbRestaurant);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRestaurantDTO>> UpdateRestaurant(UpdateRestaurantDTO updateRestaurant)
        {
            ServiceResponse<GetRestaurantDTO> serviceResponse = new ServiceResponse<GetRestaurantDTO>();

            try
            {
                Restaurant restaurant = await _context.Restaurants.FirstOrDefaultAsync(c => c.Id == updateRestaurant.Id);
                restaurant.Name = updateRestaurant.Name;
                restaurant.Cuisine = updateRestaurant.Cuisine;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Visited = updateRestaurant.Visited;
                restaurant.Deleted = updateRestaurant.Deleted;

                _context.Restaurants.Update(restaurant);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetRestaurantDTO>(restaurant);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRestaurantDTO>>> DeleteRestaurant(int id)
        {
            ServiceResponse<List<GetRestaurantDTO>> serviceResponse = new ServiceResponse<List<GetRestaurantDTO>>();

            try
            {
                Restaurant restaurant = await _context.Restaurants.FirstAsync(c => c.Id == id);
                _context.Restaurants.Remove(restaurant);

                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Restaurants.Select(c => _mapper.Map<GetRestaurantDTO>(c))).ToList();
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