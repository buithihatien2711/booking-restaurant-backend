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
        }

        public List<Reservation> GetListReservation(Guid? restaurantId, int? status)
        {
            var reservations = _context.Reservations.Include(r => r.Restaurant).AsQueryable();
            if(restaurantId == null){
                if(status == null){
                    return reservations.ToList();
                }
                else {
                    reservations = reservations.Where(r => (int)r.ReservationStatus == status);
                    return reservations.ToList();
                }
            }
            else {
                reservations = reservations.Where(r => r.RestaurantId == restaurantId);
                if(status == null){
                    return reservations.ToList();
                }
                else {
                    reservations = reservations.Where(r => (int)r.ReservationStatus == status);
                    return reservations.ToList();
                }
            }
        }

        public bool IsSaveChange()
        {
            return _context.SaveChanges() > 0;
        }
    }
}