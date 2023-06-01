using backend.DTOs.RestaurantDTO;

namespace backend.Services.RestaurantService
{
    public interface IServicesService
    {
        List<ServiceDto> GetAllService();

        List<ServiceDto> GetServiceOfRestaurant(Guid restaurantId);
    }
}