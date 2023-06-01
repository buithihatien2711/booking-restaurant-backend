using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repository.RestaurantRepository
{
    public class CuisineRepository : ICuisineRepository
    {
        private readonly DataContext _context;

        public CuisineRepository(DataContext context)
        {
            _context = context;
            
        }

        public List<TypeOfCuisine> GetAllCuisine()
        {
            return _context.TypeOfCuisines.ToList();
        }

        public List<TypeOfCuisine>? GetCuisineOfRestaurant(Guid restaurantId)
        {
            // var cuisines = _context.RestaurantCuisines
            //                 .Join(_context.TypeOfCuisines, rc => rc.CuisineId, c => c.Id, (rc, c) => {rc, c})
            //                 .Where(joinResult => joinResult.rc.RestaurantId == restaurantId)
            //                 .Select(joinResult => new TypeOfCuisine
            //                 {
            //                     Id = joinResult.c.CuisineId,
            //                     Name = joinResult.c.Name
            //                 })
            //                 .ToList();

            var restaurant = _context.Restaurants.Where(r => r.Id == restaurantId)
                                    .Select(r => new {
                                        Cuisines = r.RestaurantCuisines == null ? null : r.RestaurantCuisines.Select(rc => rc.TypeOfCuisine)
                                    }).FirstOrDefault();

            if(restaurant == null || restaurant.Cuisines == null){
                return null;
            }
            
            return restaurant.Cuisines.ToList();
        }
    }
}