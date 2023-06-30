using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repository.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext _context;

        public ReservationRepository(DataContext context)
        {
            _context = context;
        }

        public void AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == reservation.RestaurantId);
            if(restaurant != null) {
                restaurant.NumberReservation = restaurant.NumberReservation + 1;
            }
        }

        public void ChangeReservationStatus(Reservation reservation, ReservationStatus status)
        {
            reservation.ReservationStatus = status;
        }

        public List<Reservation>? GetListReservation(Guid? restaurantId, int? status, DateTime? date)
        {
            var reservations = _context.Reservations.Include(r => r.Restaurant).AsQueryable();
            if(restaurantId != null) {
                reservations = reservations.Where(r => r.RestaurantId == restaurantId);
            }
            if(status != null) {
                reservations = reservations.Where(r => (int)r.ReservationStatus == status);
            }
            if(date != null) {
                reservations = reservations.Where(r => r.Time.Date == date.Value.Date);
            }
            return reservations.ToList();

            // if(restaurantId == null){
            //     if(status == null){
            //         if(date == null) 
            //         {
            //             // restaurantId == null, status == null, date == null
            //             return reservations.ToList();
            //         }
            //         else
            //         {
            //             // restaurantId == null, status == null, date != null
            //             return reservations.Where(r => r.Time.Date == date).ToList();
            //         }
            //     }
            //     else {
            //         reservations = reservations.Where(r => (int)r.ReservationStatus == status);
            //         if(date == null) 
            //         {
            //             // restaurantId == null, status != null, date == null
            //             return reservations.ToList();
            //         }
            //         else
            //         {
            //             // restaurantId == null, status != null, date != null
            //             return reservations.Where(r => r.Time.Date == date).ToList();
            //         }
            //     }
            // }
            // else {
            //     reservations = reservations.Where(r => r.RestaurantId == restaurantId);
            //     if(status == null){
            //         if(date == null) 
            //         {
            //             // restaurantId != null, status == null, date == null
            //             return reservations.ToList();
            //         }
            //         else
            //         {
            //             // restaurantId != null, status == null, date != null
            //             return reservations.Where(r => r.Time.Date == date).ToList();
            //         }
            //     }
            //     else {
            //         reservations = reservations.Where(r => (int)r.ReservationStatus == status);
            //         if(date == null) 
            //         {
            //             // restaurantId != null, status != null, date == null
            //             return reservations.ToList();
            //         }
            //         else
            //         {
            //             // restaurantId != null, status != null, date != null
            //             return reservations.Where(r => r.Time.Date == date).ToList();
            //         }
            //     }
            // }
        }

        public Reservation? GetReservationById(Guid reservationId)
        {
            return _context.Reservations.FirstOrDefault(r => r.Id == reservationId);
        }

        public List<Restaurant> GetRestaurantAdmin(int pageIndex, int? status)
        {
            throw new NotImplementedException();
        }

        public bool IsSaveChange()
        {
            return _context.SaveChanges() > 0;
        }
    }
}