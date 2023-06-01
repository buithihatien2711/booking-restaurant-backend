using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class ExtraService
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public List<RestaurantExtraService>? RestaurantExtraServices { get; set; }
        
        
    }
}