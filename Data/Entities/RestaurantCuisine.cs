using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class RestaurantCuisine
    {
        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
        
        public Guid CuisineId { get; set; }

        public TypeOfCuisine TypeOfCuisine { get; set; }
    }
}