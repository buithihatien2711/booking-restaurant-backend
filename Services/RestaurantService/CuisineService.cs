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
    public class CuisineService : ICuisineService
    {
        private readonly ICuisineRepository _cuisineRepository;
        private readonly IMapper _mapper;

        public CuisineService(ICuisineRepository cuisineRepository, IMapper mapper)
        {
            _cuisineRepository = cuisineRepository;
            _mapper = mapper;
        }

        public List<CuisineDto> GetAllCuisine()
        {
            var cuisines = _cuisineRepository.GetAllCuisine();
            return _mapper.Map<List<TypeOfCuisine>, List<CuisineDto>>(cuisines);
        }

        public List<CuisineDto> GetCuisineOfRestaurant(Guid restaurantId)
        {
            var cuisines = _cuisineRepository.GetCuisineOfRestaurant(restaurantId);
            return _mapper.Map<List<TypeOfCuisine>, List<CuisineDto>>(cuisines);
        }
    }
}