using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.DTOs.RestaurantDTO
{
    public class BusinessHourDto
    {
        public Guid Id { get; set; }

        public Data.Entities.DayOfWeek Date { get; set; }

        public TimeSpan OpenTime { get; set; }
        
        public TimeSpan CloseTime { get; set; }
    }
}