using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.Data.Repository.RestaurantRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DataContext _context;
        public ServiceRepository(DataContext context)
        {
            _context = context;
            
        }

        public List<TypeOfService> GetAllService()
        {
            return _context.TypeOfServices.ToList();
        }

        public List<TypeOfService>? GetServiceOfRestaurant(Guid restaurantId)
        {
            var restaurant = _context.Restaurants.Where(r => r.Id == restaurantId)
                                    .Select(r => new {
                                        Services = r.RestaurantServices == null ? null : r.RestaurantServices.Select(rc => rc.TypeOfService)
                                    }).FirstOrDefault();

            if(restaurant == null || restaurant.Services == null){
                return null;
            }
            
            return restaurant.Services.ToList();
        }
    }
}