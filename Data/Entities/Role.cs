using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<User>? Users { get; set; }

        public Role() { }

        public Role(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}