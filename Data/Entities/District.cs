using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class District
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [MaxLength(256)]
        public string? Name { get; set; }

        public int CityId { get; set; }
        
        public City City { get; set; }

        List<Ward>? Wards { get; set; }
    }
}