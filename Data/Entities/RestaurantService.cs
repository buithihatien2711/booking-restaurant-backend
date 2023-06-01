using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class RestaurantService
    {
        public Guid RestaurantId { get; set; }
        
        public Restaurant Restaurant { get; set; }
        
        public int ServiceId { get; set; }

        public TypeOfService TypeOfService { get; set; }
    }
}