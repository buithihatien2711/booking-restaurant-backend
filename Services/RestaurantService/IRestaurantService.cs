using backend.DTOs;
using backend.DTOs.RestaurantDTO;

namespace backend.Services.RestaurantService
{
    public interface IRestaurantService
    {
        List<RestaurantOverviewDto>? GetListRestaurant(string? filter, int pageIndex);

        
    }
}