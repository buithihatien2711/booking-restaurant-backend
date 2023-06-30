using backend.Data.Entities;
using backend.DTOs.LocationDTO;

namespace backend.DTOs.RestaurantDTO
{
    public class RestaurantOverviewDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public LocationDto? Location { get; set; }

        public WardDto? Ward { get; set; }
        
        public DistrictDto? District { get; set; }
        
        public CityDto? City { get; set; }
        
        public List<CuisineDto>? Cuisines { get; set; }
        
        public List<ServiceDto>? Services { get; set; }
        
        public PriceRange PriceRange { get; set; }

        public string? Image { get; set; }
        
        
    }
}