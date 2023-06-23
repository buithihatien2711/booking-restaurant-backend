using AutoMapper;
using backend.Data.Entities;
using backend.DTOs.LocationDTO;
using backend.DTOs.ReservationDTO;
using backend.DTOs.RestaurantDTO;

namespace backend.Mapping
{
    public class AutoMappingConfiguration : Profile
    {
        public AutoMappingConfiguration()
        {
            CreateMap<TypeOfCuisine, CuisineDto>();
            CreateMap<TypeOfService, ServiceDto>();
            CreateMap<Suitability, SuitabilityDto>();
            CreateMap<MenuImage, ImageDto>();
            CreateMap<RestaurantImage, ImageDto>();
            CreateMap<BusinessHour, BusinessHourDto>();
            CreateMap<ExtraService, ExtraServiceDto>();
            CreateMap<TypeOfCuisine, CuisineDto>();
            CreateMap<City, CityDto>();
            CreateMap<District, DistrictDto>();
            CreateMap<Ward, WardDto>();
            CreateMap<Reservation, ReservationOverviewDto>();
            CreateMap<Reservation, ReservationDetailDto>();
            // CreateMap<ReservationDto, Reservation>();
        }
    }
}