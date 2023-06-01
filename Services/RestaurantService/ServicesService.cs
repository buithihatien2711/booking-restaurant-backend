using AutoMapper;
using backend.Data.Entities;
using backend.Data.Repository.RestaurantRepository;
using backend.DTOs.RestaurantDTO;

namespace backend.Services.RestaurantService
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServicesService(IServiceRepository serviceRepository, IMapper mapper)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }
        public List<ServiceDto> GetAllService()
        {
            var services = _serviceRepository.GetAllService();
            return _mapper.Map<List<TypeOfService>, List<ServiceDto>>(services);
        }

        public List<ServiceDto> GetServiceOfRestaurant(Guid restaurantId)
        {
            var services = _serviceRepository.GetServiceOfRestaurant(restaurantId);
            return _mapper.Map<List<TypeOfService>, List<ServiceDto>>(services);
        }
    }
}