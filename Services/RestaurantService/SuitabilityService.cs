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
    public class SuitabilityService : ISuitabilityService
    {
        private readonly IMapper _mapper;
        private readonly ISuitabilityRepository _suitabilityRepository;
        public SuitabilityService(ISuitabilityRepository suitabilityRepository, IMapper mapper)
        {
            _suitabilityRepository = suitabilityRepository;
            _mapper = mapper;
            
        }

        public List<SuitabilityDto> GetAllSuitability()
        {
            var suitabilities = _suitabilityRepository.GetAllSuitability();
            return _mapper.Map<List<Suitability>, List<SuitabilityDto>>(suitabilities);
        }

        public List<SuitabilityDto>? GetSuitabilityOfRestaurant(Guid restaurantId)
        {
            var suitabilities = _suitabilityRepository.GetSuitabilityOfRestaurant(restaurantId);
            if(suitabilities == null) {
                return null;
            }
            return _mapper.Map<List<Suitability>, List<SuitabilityDto>>(suitabilities);
        }
    }
}