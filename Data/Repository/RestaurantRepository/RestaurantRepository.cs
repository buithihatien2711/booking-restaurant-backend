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
        public static int PAGE_SIZE { get; set; } = 15;
        private readonly DataContext _context;

        public RestaurantRepository(DataContext context)
        {
            _context = context;
            
        }

        // Get Restaurant by criteria
        public List<Restaurant>? GetListRestaurant(string? filter, int page = 1)
        {
            var restaurants = _context.Restaurants.Include(r => r.Location).ThenInclude(l => l.Ward).ThenInclude(w => w.District).ThenInclude(d => d.City)
                                                    .Include(r => r.RestaurantCuisines)
                                                    .Include(r => r.RestaurantServices)
                                                    .Include(r => r.RestaurantSuitabilities)
                                                    .Include(r => r.RestaurantImages)
                                                    .Skip((page - 1)*PAGE_SIZE).Take(PAGE_SIZE).ToList();
            
            // if(filter == "top-restaurant")
            // {
            //     // restaurants = restaurants.OrderByDescending();
            // }

            // Page, auto return page 1

            ///
            
            return restaurants;
        }

        public Restaurant? GetRestaurantById(Guid idRestaurant)
        {
            var restaurant = _context.Restaurants.Include(r => r.Location).ThenInclude(l => l.Ward).ThenInclude(w => w.District).ThenInclude(d => d.City)
                                                    .Include(r => r.RestaurantCuisines)
                                                    .Include(r => r.RestaurantServices)
                                                    .Include(r => r.RestaurantSuitabilities)
                                                    .Include(r => r.RestaurantImages)
                                                    .Include(r => r.BusinessHours)
                                                    .Include(r => r.RestaurantExtraServices)
                                                    .Include(r => r.MenuImages)
                                                    .FirstOrDefault(r => r.Id == idRestaurant);
                                                    

            return restaurant;
        }

        public Guid? GetRestaurantIdByUser(Guid idUser)
        {
            var user = _context.Users.Include(u => u.Restaurant).FirstOrDefault(u => u.Id == idUser);
            if (user != null)
            {
                if (user.Restaurant != null)
                {
                    var id = user.Restaurant.Id;
                    return user.Restaurant.Id;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public bool IsSaveChange()
        {
            return _context.SaveChanges() > 0;
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            _context.Add(restaurant);
        }
    }
}