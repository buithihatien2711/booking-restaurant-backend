using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.RestaurantDTO
{
    public class BusinessHourDto
    {
        public Guid Id { get; set; }

        public DayOfWeek Date { get; set; }

        public TimeSpan OpenTime { get; set; }
        
        public TimeSpan CloseTime { get; set; }
    }
}