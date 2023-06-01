using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.RestaurantDTO;

namespace backend.Services.RestaurantService
{
    public interface ICuisineService
    {
        List<CuisineDto> GetAllCuisine();

        List<CuisineDto> GetCuisineOfRestaurant(Guid restaurantId);
    }
}