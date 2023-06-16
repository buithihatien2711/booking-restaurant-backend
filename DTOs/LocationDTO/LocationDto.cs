using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.LocationDTO
{
    public class LocationDto
    {
        public Guid? Id { get; set; }
        
        public string Address { get; set; }
        
        // public WardDto Ward { get; set; }
    }
}