using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class MenuImage
    {
        public Guid Id { get; set; }
        
        public string URL { get; set; }
        
        public Guid RestaurantId { get; set; }
        
        public Restaurant Restaurant { get; set; }
        
        
    }
}