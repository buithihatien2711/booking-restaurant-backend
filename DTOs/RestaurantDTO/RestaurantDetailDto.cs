using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.LocationDTO;

namespace backend.DTOs.RestaurantDTO
{
    public class RestaurantDetailDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public LocationDto Location { get; set; }

        public WardDto Ward { get; set; }
        
        public DistrictDto District { get; set; }
        
        public CityDto City { get; set; }

        public List<CuisineDto>? Cuisines { get; set; }
        
        public List<ServiceDto>? Services { get; set; }
        
        public int Capacity { get; set; }
        
        public string? SpecialDishes { get; set; }
        
        public string? Introduction { get; set; }
        
        public string? Note { get; set; }
        
        public List<ImageDto>? RestaurantImages { get; set; }

        public List<ImageDto>? MenuImages { get; set; }
        
        public List<BusinessHourDto>? BusinessHours { get; set; }
        
        public List<ExtraServiceDto>? ExtraServices { get; set; }
    }
}