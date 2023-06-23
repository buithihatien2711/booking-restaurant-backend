using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.DTOs.ReservationDTO
{
    public class ReservationDetailDto
    {
        public Guid Id { get; set; }
        
        public DateTime Time { get; set; }
        
        public int NumAdults { get; set; }
        
        public int NumChildren { get; set; }
        
        public string? Note { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        // public DateTime UpdateAt { get; set; }
        
        public ReservationStatus ReservationStatus { get; set; }

        public string NameCustomer { get; set; }
        
        public string PhoneCustomer { get; set; }
    }
}