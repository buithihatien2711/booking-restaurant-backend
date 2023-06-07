using AutoMapper;
using backend.Data.Entities;
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
            CreateMap<MenuImage, MenuImageDto>();
            CreateMap<BusinessHour, BusinessHourDto>();
            CreateMap<ExtraService, ExtraServiceDto>();
        }
    }
}