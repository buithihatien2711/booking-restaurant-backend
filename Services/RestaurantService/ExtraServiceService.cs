using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data.Entities;
using backend.Data.Repository.RestaurantRepository;
using backend.DTOs.RestaurantDTO;

namespace backend.Services.RestaurantService
{
    public class ExtraServiceService : IExtraServiceService
    {
        private readonly IExtraServiceRepository _extraServiceRepository;
        private readonly IMapper _mapper;

        public ExtraServiceService(IExtraServiceRepository extraServiceRepository, IMapper mapper)
        {
            _extraServiceRepository = extraServiceRepository;
            _mapper = mapper;
        }
        public List<ExtraServiceDto>? GetAllExtraService()
        {
            var extraServices = _extraServiceRepository.GetAllExtraService();
            if(extraServices == null) return null;
            return _mapper.Map<List<ExtraService>, List<ExtraServiceDto>>(extraServices);
        }

        public List<ExtraServiceDto>? GetExtraServiceOfRestaurant(Guid restaurantId)
        {
            var extraServices = _extraServiceRepository.GetExtraServiceOfRestaurant(restaurantId);
            if(extraServices == null) return null;
            return _mapper.Map<List<ExtraService>, List<ExtraServiceDto>>(extraServices);
        }
    }
}