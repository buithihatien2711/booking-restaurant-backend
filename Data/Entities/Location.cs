using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class Location
    {
        [Key]
        public Guid Id { get; set; }
        
        [MaxLength(256)]
        public string? Address { get; set; }
        
        public int? WardId { get; set; }
        
        public Ward? Ward { get; set; }

        public Guid? RestaurantId { get; set; }
        
        public Restaurant? Restaurant { get; set; }

    }
}