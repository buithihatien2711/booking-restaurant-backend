using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class Ward
    {
        public int Id { get; set; }
        
        [MaxLength(256)]
        public string? Name { get; set; }

        public int DistrictID  { get; set; }
        
        public District? District { get; set; }

        public List<Location>? Locations { get; set; }
    }
}