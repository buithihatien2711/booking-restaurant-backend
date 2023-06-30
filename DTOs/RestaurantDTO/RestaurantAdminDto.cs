using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;
using backend.DTOs.LocationDTO;

namespace backend.DTOs.RestaurantDTO
{
    public class RestaurantAdminDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string? Phone { get; set; }
        
        public PriceRange PriceRange { get; set; }
        
        public int Capacity { get; set; }
        
        public string? SpecialDishes { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public string? City { get; set; }

        public RestaurantStatus? RestaurantStatus { get; set; }
    }
}