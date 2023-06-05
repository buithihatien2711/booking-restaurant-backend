using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.Data.Repository.RestaurantRepository
{
    public interface IRestaurantRepository
    {
        List<Restaurant>? GetListRestaurant(string? filter, int page = 1);
    }
}