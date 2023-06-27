using backend.DTOs;
using backend.DTOs.RestaurantDTO;

namespace backend.Services.RestaurantService
{
    public interface IRestaurantService
    {
        List<RestaurantOverviewDto>? GetListRestaurant(string? filter, int pageIndex);

        RestaurantDetailDto? GetRestaurantById(Guid idRestaurant);

        Guid? GetRestaurantIdByUser(Guid idUser);

        void AddRestaurant(RestaurantAddDto restaurant, Guid userId);

        bool IsSaveChange();
    }
}