using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class BusinessHour
    {
        [Key]
        public Guid Id { get; set; }

        public DayOfWeek Date { get; set; }

        public TimeSpan OpenTime { get; set; }
        
        public TimeSpan CloseTime { get; set; }
        
        public Guid RestaurantId { get; set; }
        
        public Restaurant Restaurant { get; set; }
    }
}