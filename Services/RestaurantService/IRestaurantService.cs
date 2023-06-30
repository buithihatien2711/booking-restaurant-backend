using backend.Data.Entities;
using backend.DTOs;
using backend.DTOs.RestaurantDTO;

namespace backend.Services.RestaurantService
{
    public interface IRestaurantService
    {
        List<RestaurantOverviewDto>? GetListRestaurant(string? filter, int pageIndex);

        (List<RestaurantOverviewDto>?, int) FilterRestaurant(FilterRestaurantDto filter, int pageIndex);

        RestaurantDetailDto? GetRestaurantById(Guid idRestaurant);

        Guid? GetRestaurantIdByUser(Guid idUser);

        void AddRestaurant(RestaurantAddDto restaurant, Guid userId);

        bool IsSaveChange();

        (List<RestaurantAdminDto>, int) GetListRestaurantAdmin(int pageIndex, int? status);

        // int GetTotalPage();

        void ChangeRestaurantStatus(Guid restaurantId, RestaurantStatus status);
    }
}