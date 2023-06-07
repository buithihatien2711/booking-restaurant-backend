using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.Data.Repository.RestaurantRepository
{
    public class ExtraServiceRepository : IExtraServiceRepository
    {
        private readonly DataContext _context;

        public ExtraServiceRepository(DataContext context)
        {
            _context = context;
        }

        public List<ExtraService>? GetAllExtraService()
        {
            return _context.ExtraServices.ToList();
        }

        public List<ExtraService>? GetExtraServiceOfRestaurant(Guid restaurantId)
        {
            var restaurant = _context.Restaurants.Where(r => r.Id == restaurantId)
                                    .Select(r => new {
                                        ExtraServices = r.RestaurantExtraServices == null ? null : r.RestaurantExtraServices.Select(res => res.ExtraService)
                                    }).FirstOrDefault();

            if(restaurant == null || restaurant.ExtraServices == null){
                return null;
            }
            
            return restaurant.ExtraServices.ToList();
        }
    }
}