using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;
using backend.DTOs.RestaurantDTO;
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

        public (List<Restaurant>, int) GetListRestaurantAdmin(int pageIndex, RestaurantStatus? status)
        {
            var restaurants = _context.Restaurants.Include(r => r.Location)
                                                    .ThenInclude(l => l.Ward)
                                                    .ThenInclude(w => w.District)
                                                    .ThenInclude(d => d.City)
                                                    .AsQueryable();
            if(status != null) {
                restaurants = restaurants.Where(r => r.RestaurantStatus == status);
            }

            int totalRow = restaurants.Count();
            int totalPage = (int)Math.Ceiling((double)totalRow / PAGE_SIZE);

            restaurants = restaurants.Skip((pageIndex - 1)*PAGE_SIZE).Take(PAGE_SIZE);
            
            return (restaurants.ToList(), totalPage);
        }

        // public int GetTotalPageRestaurant()
        // {
        //     int totalRow = _context.Restaurants.Count();
        //     return (int)Math.Ceiling((double)totalRow / PAGE_SIZE);
        // }

        public void ChangeRestaurantStatus(Restaurant restaurant, RestaurantStatus status)
        {
            restaurant.RestaurantStatus = status;
        }

        public (List<Restaurant>?, int) FilterRestaurant(FilterRestaurantDto filter, int pageIndex)
        {
            var restaurants = _context.Restaurants.Include(r => r.Location).ThenInclude(l => l.Ward).ThenInclude(w => w.District).ThenInclude(d => d.City)
                                        .Include(r => r.RestaurantCuisines)
                                        .Include(r => r.RestaurantServices)
                                        .Include(r => r.RestaurantSuitabilities)
                                        .Include(r => r.RestaurantImages).AsSplitQuery();
                                        // .Skip((pageIndex - 1)*PAGE_SIZE).Take(PAGE_SIZE).ToList();
            if(filter.City.HasValue) {
                restaurants = restaurants.Where(r => r.Location.Ward.District.CityId == filter.City);
            }
            if(filter.District.HasValue) {
                restaurants = restaurants.Where(r => r.Location.Ward.DistrictID == filter.District);
            }
            if(filter.PriceRange.HasValue) {
                restaurants = restaurants.Where(r => (int)r.PriceRange == filter.PriceRange);
            }
            if(filter.Cuisine.HasValue) {
                restaurants = restaurants.Where(r => r.RestaurantCuisines.Any(rc => rc.TypeOfCuisineId == filter.Cuisine));
            }
            if(filter.Service.HasValue) {
                restaurants = restaurants.Where(r => r.RestaurantServices.Any(rs => rs.TypeOfServiceId == filter.Service));
            }
            if(filter.Suitability.HasValue) {
                restaurants = restaurants.Where(r => r.RestaurantSuitabilities.Any(rs => rs.SuitabilityId == filter.Suitability));
            }
            if(string.IsNullOrEmpty(filter.Sort)) {
                restaurants = restaurants.OrderByDescending(r => r.NumberReservation);
            }
            // Sort theo filter.Sort
            if(filter.Sort == "popular") {
                restaurants = restaurants.OrderByDescending(r => r.NumberReservation);
            }
            if(filter.Sort == "price-increase") {
                restaurants = restaurants.OrderBy(r => r.PriceRange);
            }
            if(filter.Sort == "price-decrease") {
                restaurants = restaurants.OrderByDescending(r => r.PriceRange);
            }

            int totalRow = restaurants.Count();
            int totalPage = (int)Math.Ceiling((double)totalRow / PAGE_SIZE);

            if(restaurants.Count() > 0) {
                restaurants = restaurants.Skip((pageIndex - 1)*PAGE_SIZE).Take(PAGE_SIZE);
                return (restaurants.ToList(), totalPage);
            }
            return (new List<Restaurant>(), 0);
        }
    }
}