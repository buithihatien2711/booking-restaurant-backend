using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class RestaurantSuitability
    {
        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
        
        public int SuitabilityId { get; set; }
        
        public Suitability Suitability { get; set; }
        
        
    }
}