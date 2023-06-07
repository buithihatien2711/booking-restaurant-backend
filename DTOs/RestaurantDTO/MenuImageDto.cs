using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.RestaurantDTO
{
    public class MenuImageDto
    {
        public Guid Id { get; set; }
        
        public string URL { get; set; }
    }
}