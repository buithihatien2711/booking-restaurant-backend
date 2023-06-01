using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.Data.Repository.RestaurantRepository
{
    public interface ICuisineRepository
    {
        List<TypeOfCuisine> GetAllCuisine();

        List<TypeOfCuisine>? GetCuisineOfRestaurant(Guid restaurantId);
    }
}