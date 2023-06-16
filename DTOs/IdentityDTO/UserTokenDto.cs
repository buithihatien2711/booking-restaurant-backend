using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.IdentityDTO
{
    public class UserTokenDto
    {
        public Guid Id { get; set; }
        
        
        public string Fullname { get; set; }
        
        public string Phone { get; set; }

        public string Email { get; set; }
        
    }
}