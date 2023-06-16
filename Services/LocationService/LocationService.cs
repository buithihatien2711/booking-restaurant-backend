using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data.Entities;
using backend.Data.Repository.LocationRepository;
using backend.DTOs.LocationDTO;

namespace backend.Services.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public List<CityDto>? GetAllCity()
        {
            var cities = _locationRepository.GetAllCity();
            if(cities == null) return null;
            return _mapper.Map<List<City>, List<CityDto>>(cities);
        }

        public List<DistrictDto>? GetDistrictsOfCity(int cityId)
        {
            var districts = _locationRepository.GetDistrictsOfCity(cityId);
            if(districts == null) return null;
            return _mapper.Map<List<District>, List<DistrictDto>>(districts);
        }

        public List<WardDto>? GetWardsOfDistrict(int districtId)
        {
            var wards = _locationRepository.GetWardsOfDistrict(districtId);
            if(wards == null) return null;
            return _mapper.Map<List<Ward>, List<WardDto>>(wards);
        }
    }
}