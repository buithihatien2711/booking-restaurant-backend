using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.RestaurantDTO;

namespace backend.Services.RestaurantService
{
    public interface IExtraServiceService
    {
        List<ExtraServiceDto>? GetAllExtraService();

        List<ExtraServiceDto>? GetExtraServiceOfRestaurant(Guid restaurantId);
    }
}