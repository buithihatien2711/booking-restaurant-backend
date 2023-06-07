using AutoMapper;
using backend.Data.Entities;
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
        private readonly IExtraServiceService _extraServiceService;

        public RestaurantService(IRestaurantRepository restaurantRepository, ICuisineService cuisineService, IServicesService servicesService, ISuitabilityService suitabilityService, IExtraServiceService extraServiceService, IMapper mapper)
        {
            _extraServiceService = extraServiceService;
            _suitabilityService = suitabilityService;
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _cuisineService = cuisineService;
            _servicesService = servicesService;
        }

        public List<RestaurantOverviewDto>? GetListRestaurant(string? filter, int pageIndex)
        {
            var restaurants = _restaurantRepository.GetListRestaurant(filter, pageIndex);
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
                        // Id = restaurant.LocationId,
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
                    },
                    Image = restaurant.RestaurantImages == null ? null : restaurant.RestaurantImages[0].URL
                });
            }
            return restaurantOverviews;
        }

        public RestaurantDetailDto? GetRestaurantById(Guid idRestaurant)
        {
            var restaurant = _restaurantRepository.GetRestaurantById(idRestaurant);
            var cuisines = _cuisineService.GetCuisineOfRestaurant(restaurant.Id);
            var services = _servicesService.GetServiceOfRestaurant(restaurant.Id);
            var extraServices = _extraServiceService.GetExtraServiceOfRestaurant(restaurant.Id);

            if(restaurant == null) {
                return null;
            }

            return new RestaurantDetailDto()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Cuisines = cuisines,
                Services = services,
                Location = new LocationDto(){
                    // Id = restaurant.LocationId,
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
                },
                Capacity = restaurant.Capacity,
                SpecialDishes = restaurant.SpecialDishes,
                Introduction = restaurant.Introduction,
                Note = restaurant.Note,
                MenuImages = restaurant.MenuImages == null ? null : _mapper.Map<List<MenuImage>, List<MenuImageDto>>(restaurant.MenuImages),
                BusinessHours = restaurant.BusinessHours == null ? null : _mapper.Map<List<BusinessHour>, List<BusinessHourDto>>(restaurant.BusinessHours),
                ExtraServices = extraServices
            };
        }
    }
}