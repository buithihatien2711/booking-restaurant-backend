using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repository.RestaurantRepository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DataContext _context;

        public RestaurantRepository(DataContext context)
        {
            _context = context;
            
        }

        // Get Restaurant by criteria
        public List<Restaurant>? GetListRestaurant(string? filter)
        {
            var restaurants = _context.Restaurants.Include(r => r.Location).ThenInclude(l => l.Ward).ThenInclude(w => w.District).ThenInclude(d => d.City)
                                                    .Include(r => r.RestaurantCuisines)
                                                    .Include(r => r.RestaurantServices)
                                                    .Include(r => r.RestaurantSuitabilities).ToList();
            
            // if(filter == "top-restaurant")
            // {
            //     // restaurants = restaurants.OrderByDescending();
            // }
            return restaurants;
        }
    }
}