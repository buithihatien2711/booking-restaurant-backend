using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class Suitability
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<RestaurantSuitability> RestaurantSuitabilities { get; set; }
        
        public Suitability() { }

        public Suitability(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}