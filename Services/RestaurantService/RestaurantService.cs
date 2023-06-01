using AutoMapper;
using backend.Data.Repository.RestaurantRepository;
using backend.DTOs.LocationDTO;
using backend.DTOs.RestaurantDTO;

namespace backend.Services.RestaurantService
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICuisineService _cuisineService;
        private readonly IServicesService _servicesService;
        private readonly IMapper _mapper;
        private readonly ISuitabilityService _suitabilityService;

        public RestaurantService(IRestaurantRepository restaurantRepository, ICuisineService cuisineService, IServicesService servicesService, ISuitabilityService suitabilityService, IMapper mapper)
        {
            _suitabilityService = suitabilityService;
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _cuisineService = cuisineService;
            _servicesService = servicesService;
        }

        public List<RestaurantOverviewDto>? GetListRestaurant(string? filter)
        {
            var restaurants = _restaurantRepository.GetListRestaurant(filter);
            if(restaurants == null) {
                return null;
            }
            var restaurantOverviews = new List<RestaurantOverviewDto>();

            foreach (var restaurant in restaurants)
            {
                var cuisines = _cuisineService.GetCuisineOfRestaurant(restaurant.Id);
                var services = _servicesService.GetServiceOfRestaurant(restaurant.Id);

                restaurantOverviews.Add(new RestaurantOverviewDto()
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    Cuisines = cuisines,
                    Services = services,
                    PriceRange = restaurant.PriceRange,
                    Location = new LocationDto(){
                        Id = restaurant.LocationId,
                        Address = restaurant.Location.Address,
                        Ward = new WardDto() {
                            Id = restaurant.Location.Ward.Id,
                            Name = restaurant.Location.Ward.Name,
                            District = new DistrictDto() {
                                Id = restaurant.Location.Ward.District.Id,
                                Name = restaurant.Location.Ward.District.Name,
                                City = new CityDto() {
                                    Id = restaurant.Location.Ward.District.CityId,
                                    Name = restaurant.Location.Ward.District.City.Name
                                }
                            }
                        }
                    }
                });
            }
            return restaurantOverviews;
        }
    }
}