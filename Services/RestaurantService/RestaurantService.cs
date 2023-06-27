using System.Globalization;
using AutoMapper;
using backend.Data.Entities;
using backend.Data.Repository.RestaurantRepository;
using backend.DTOs.LocationDTO;
using backend.DTOs.RestaurantDTO;
using backend.Services.UploadImageService;

namespace backend.Services.RestaurantService
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICuisineService _cuisineService;
        private readonly IServicesService _servicesService;
        private readonly IMapper _mapper;
        private readonly IUploadImageService _uploadImageService;
        private readonly ISuitabilityService _suitabilityService;
        private readonly IExtraServiceService _extraServiceService;

        public RestaurantService(IRestaurantRepository restaurantRepository, 
                                    ICuisineService cuisineService, 
                                    IServicesService servicesService, 
                                    ISuitabilityService suitabilityService, 
                                    IExtraServiceService extraServiceService, 
                                    IMapper mapper, IUploadImageService uploadImageService)
        {
            _extraServiceService = extraServiceService;
            _suitabilityService = suitabilityService;
            _mapper = mapper;
            _uploadImageService = uploadImageService;
            _restaurantRepository = restaurantRepository;
            _cuisineService = cuisineService;
            _servicesService = servicesService;
        }

        public void AddRestaurant(RestaurantAddDto restaurant, Guid userId)
        {
            var restaurantImages = new List<RestaurantImage>();
            if(restaurant.RestaurantImages != null) {
                foreach (var image in restaurant.RestaurantImages)
                {
                    // var url = await _uploadImageService.UploadImage(userId.ToString(), "Restaurant Image", DateTime.Now.ToString(), image);
                    restaurantImages.Add(new RestaurantImage() {
                        Id = new Guid(),
                        URL = image,
                    });
                }
            }

            var menuImages = new List<MenuImage>();
            if(restaurant.MenuImages != null) {
                foreach (var image in restaurant.MenuImages)
                {
                    // var url = await _uploadImageService.UploadImage(userId.ToString(), "Restaurant Image", DateTime.Now.ToString(), image);
                    menuImages.Add(new MenuImage() {
                        Id = new Guid(),
                        URL = image,
                    });
                }
            }

            var cuisines = new List<RestaurantCuisine>();
            if(restaurant.Cuisines != null) {
                foreach (var cuisine in restaurant.Cuisines)
                {
                    cuisines.Add(new RestaurantCuisine() {
                        TypeOfCuisineId = cuisine
                    });
                }
            }

            var services = new List<Data.Entities.RestaurantService>();
            if(restaurant.Services != null) {
                foreach (var service in restaurant.Services)
                {
                    services.Add(new Data.Entities.RestaurantService() {
                        TypeOfServiceId = service
                    });
                }
            }

            var extraServices = new List<RestaurantExtraService>();
            if(restaurant.ExtraServices != null) {
                foreach (var extraService in restaurant.ExtraServices)
                {
                    extraServices.Add(new RestaurantExtraService() {
                        ExtraServiceId = extraService
                    });
                }
            }

            var suitabilities = new List<RestaurantSuitability>();
            if(restaurant.Suitabilities != null) {
                foreach (var suitability in restaurant.Suitabilities)
                {
                    suitabilities.Add(new RestaurantSuitability() {
                        SuitabilityId = suitability
                    });
                }
            }

            var businessHours = new List<BusinessHour>();
            if(restaurant.BusinessHours != null) {
                foreach (var businessHour in restaurant.BusinessHours)
                {
                    businessHours.Add(new BusinessHour() {
                        Id = new Guid(),
                        Date = (Data.Entities.DayOfWeek)businessHour.Date,
                        OpenTime = TimeSpan.Parse(businessHour.OpenTime),
                        CloseTime = TimeSpan.Parse(businessHour.CloseTime),
                    });
                }
            }

            _restaurantRepository.AddRestaurant(new Restaurant(){
                Id = new Guid(),
                Name = restaurant.Name,
                Phone = restaurant.Phone,
                PriceRange = (PriceRange)restaurant.PriceRange,
                Capacity = restaurant.Capacity,
                SpecialDishes = restaurant.SpecialDishes,
                Introduction = restaurant.Introduction,
                Note = restaurant.Note,
                CreateAt = DateTime.Now,
                UserId = userId,
                RestaurantImages = restaurantImages,
                RestaurantCuisines = cuisines,
                RestaurantServices = services,
                RestaurantSuitabilities = suitabilities,
                Location = new Location(){
                    Id = new Guid(),
                    Address = restaurant.Address,
                    WardId = restaurant.Ward
                },
                RestaurantExtraServices = extraServices,
                BusinessHours = businessHours,
                MenuImages = menuImages,
                RestaurantStatus = 0
            });
        }

        public List<RestaurantOverviewDto>? GetListRestaurant(string? filter, int pageIndex)
        {
            var restaurants = _restaurantRepository.GetListRestaurant(filter, pageIndex);
            if (restaurants == null)
            {
                return null;
            }
            var restaurantOverviews = new List<RestaurantOverviewDto>();

            foreach (var restaurant in restaurants)
            {
                var cuisines = _cuisineService.GetCuisineOfRestaurant(restaurant.Id);
                var services = _servicesService.GetServiceOfRestaurant(restaurant.Id);
                var imageUrl = (restaurant.RestaurantImages != null) ? (restaurant.RestaurantImages.Count > 0 ? restaurant.RestaurantImages[0].URL : null) : null;
                
                restaurantOverviews.Add(new RestaurantOverviewDto()
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    Cuisines = cuisines,
                    Services = services,
                    PriceRange = restaurant.PriceRange,
                    Location = new LocationDto()
                    {
                        Id = restaurant.Location.Id,
                        Address = restaurant.Location.Address,
                    },
                    Ward = new WardDto()
                    {
                        Id = restaurant.Location.Ward.Id,
                        Name = restaurant.Location.Ward.Name,
                    },
                    District = new DistrictDto()
                    {
                        Id = restaurant.Location.Ward.District.Id,
                        Name = restaurant.Location.Ward.District.Name,
                    },
                    City = new CityDto()
                    {
                        Id = restaurant.Location.Ward.District.CityId,
                        Name = restaurant.Location.Ward.District.City.Name
                    },
                    Image = imageUrl
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

            if (restaurant == null)
            {
                return null;
            }

            return new RestaurantDetailDto()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                RestaurantImages = restaurant.RestaurantImages == null ? null : _mapper.Map<List<RestaurantImage>, List<ImageDto>>(restaurant.RestaurantImages),
                Cuisines = cuisines,
                Services = services,
                Location = new LocationDto()
                {
                    Id = restaurant.Location.Id,
                    Address = restaurant.Location.Address,
                },
                Ward = new WardDto()
                {
                    Id = restaurant.Location.Ward.Id,
                    Name = restaurant.Location.Ward.Name,
                },
                District = new DistrictDto()
                {
                    Id = restaurant.Location.Ward.District.Id,
                    Name = restaurant.Location.Ward.District.Name,
                },
                City = new CityDto()
                {
                    Id = restaurant.Location.Ward.District.CityId,
                    Name = restaurant.Location.Ward.District.City.Name
                },
                Capacity = restaurant.Capacity,
                SpecialDishes = restaurant.SpecialDishes,
                Introduction = restaurant.Introduction,
                Note = restaurant.Note,
                MenuImages = restaurant.MenuImages == null ? null : _mapper.Map<List<MenuImage>, List<ImageDto>>(restaurant.MenuImages),
                BusinessHours = restaurant.BusinessHours == null ? null : _mapper.Map<List<BusinessHour>, List<BusinessHourDto>>(restaurant.BusinessHours),
                ExtraServices = extraServices
            };
        }

        public Guid? GetRestaurantIdByUser(Guid idUser)
        {
            return _restaurantRepository.GetRestaurantIdByUser(idUser);
        }

        public bool IsSaveChange()
        {
            return _restaurantRepository.IsSaveChange();
        }
    }
}