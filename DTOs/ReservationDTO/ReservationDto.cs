using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.ReservationDTO
{
    public class ReservationDto
    {   
        public DateTime Time { get; set; }
        
        public int NumAdults { get; set; }
        
        public int NumChildren { get; set; }
        
        public string Note { get; set; }

        public string NameCustomer { get; set; }
        
        public string PhoneCustomer { get; set; }
    }
}