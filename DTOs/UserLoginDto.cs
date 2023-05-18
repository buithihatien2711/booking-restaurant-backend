using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class UserLoginDto
    {
        [Required]
        [MaxLength(256)]
        public string Phone { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }
    }
}