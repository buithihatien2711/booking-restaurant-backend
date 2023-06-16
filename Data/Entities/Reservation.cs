using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        
        public DateTime Time { get; set; }
        
        public int NumAdults { get; set; }
        
        public int NumChildren { get; set; }
        
        public string Note { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public DateTime UpdateAt { get; set; }
        
        public Guid UserId { get; set; }
        
        public User User { get; set; }
        
        public Guid RestaurantId { get; set; }
        
        public Restaurant Restaurant { get; set; }
        
        public ReservationStatus ReservationStatus { get; set; }

        public string NameCustomer { get; set; }
        
        public string PhoneCustomer { get; set; }
    }
}