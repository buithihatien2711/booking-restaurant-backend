using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.Data.Repository.RestaurantRepository
{
    public interface IExtraServiceRepository
    {
        List<ExtraService>? GetAllExtraService();

        List<ExtraService>? GetExtraServiceOfRestaurant(Guid restaurantId);
    }
}