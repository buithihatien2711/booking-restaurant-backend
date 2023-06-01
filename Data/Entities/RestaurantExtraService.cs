using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class RestaurantExtraService
    {
        public int ExtraServiceId { get; set; }
        
        public ExtraService ExtraService { get; set; }
        
        public Guid RestaurantId { get; set; }
        
        public Restaurant Restaurant { get; set; }
    }
}