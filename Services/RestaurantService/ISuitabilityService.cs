using backend.DTOs.RestaurantDTO;

namespace backend.Services.RestaurantService
{
    public interface ISuitabilityService
    {
        List<SuitabilityDto> GetAllSuitability();

        List<SuitabilityDto>? GetSuitabilityOfRestaurant(Guid restaurantId);
    }
}