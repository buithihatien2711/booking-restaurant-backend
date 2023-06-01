using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Entities
{
    public class Restaurant
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string? Phone { get; set; }
        
        public PriceRange PriceRange { get; set; }
        
        public int Capacity { get; set; }
        
        public string? SpecialDishes { get; set; }
        
        public string? Introduction { get; set; }
        
        public string? Note { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public DateTime UpdateAt { get; set; }
        
        public Guid UserId { get; set; }
        
        public User User { get; set; }
        
        public List<RestaurantImage>? RestaurantImages { get; set; }
        
        public List<RestaurantCuisine>? RestaurantCuisines { get; set; }
        
        public List<RestaurantService>? RestaurantServices { get; set; }
        
        public List<RestaurantSuitability>? RestaurantSuitabilities { get; set; }
        
        public Guid? LocationId { get; set; }
        
        public Location? Location { get; set; }
        
        public List<RestaurantExtraService>? RestaurantExtraServices { get; set; }
        
        public List<BusinessHour>? BusinessHours { get; set; }
        
        public List<MenuImage>? MenuImages { get; set; }
        
        public List<Reservation>? Reservations { get; set; }

        
    }
}