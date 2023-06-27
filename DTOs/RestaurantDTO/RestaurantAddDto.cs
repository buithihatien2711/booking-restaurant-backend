using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;
using backend.DTOs.LocationDTO;

namespace backend.DTOs.RestaurantDTO
{
    public class RestaurantAddDto
    {   
        public string Name { get; set; }
        
        public string? Phone { get; set; }
        
        public int PriceRange { get; set; }
        
        public int Capacity { get; set; }
        
        public string? SpecialDishes { get; set; }
        
        public string? Introduction { get; set; }
        
        public string? Note { get; set; }
                        
        // public List<IFormFile>? RestaurantImages { get; set; }
        public List<string>? RestaurantImages { get; set; }
        
        public List<int>? Cuisines { get; set; }
        
        public List<int>? Services { get; set; }
        
        public List<int>? Suitabilities { get; set; }
        
        public string? Address { get; set; }
        
        public int Ward { get; set; }
        
        public List<int>? ExtraServices { get; set; }
        
        public List<BusinessHourAddDto>? BusinessHours { get; set; }
        
        // public List<IFormFile>? MenuImages { get; set; }

        public List<string>? MenuImages { get; set; }
    }
}