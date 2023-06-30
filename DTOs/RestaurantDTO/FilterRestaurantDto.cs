using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.RestaurantDTO
{
    public class FilterRestaurantDto
    {
        public int? City { get; set; }
        
        public int? District { get; set; }
        
        public int? PriceRange { get; set; }
        
        public int? Cuisine { get; set; }
        
        public int? Service { get; set; }

        public int? Suitability { get; set; }
        
        public string? Sort { get; set; }
        
        
    }
}