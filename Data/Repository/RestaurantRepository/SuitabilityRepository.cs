using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.Data.Repository.RestaurantRepository
{
    public class SuitabilityRepository : ISuitabilityRepository
    {
        private readonly DataContext _context;

        public SuitabilityRepository(DataContext context)
        {
            _context = context;
        }

        public List<Suitability>? GetAllSuitability()
        {
            return _context.Suitabilities.ToList();
        }

        public List<Suitability>? GetSuitabilityOfRestaurant(Guid restaurantId)
        {
            var restaurant = _context.Restaurants.Where(r => r.Id == restaurantId)
                                    .Select(r => new {
                                        Suitabilities = r.RestaurantSuitabilities == null ? null : r.RestaurantSuitabilities.Select(rc => rc.Suitability)
                                    }).FirstOrDefault();

            if(restaurant == null || restaurant.Suitabilities == null){
                return null;
            }
            
            return restaurant.Suitabilities.ToList();
        }
    }
}