using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.ImageDto
{
    public class ImageDto
    {
        public Guid Id { get; set; }
        
        public string URL { get; set; }
    }
}