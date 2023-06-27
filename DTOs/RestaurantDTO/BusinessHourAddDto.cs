using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.RestaurantDTO
{
    public class BusinessHourAddDto
    {
        public int Date { get; set; }

        public string OpenTime { get; set; }
        
        public string CloseTime { get; set; }
    }
}