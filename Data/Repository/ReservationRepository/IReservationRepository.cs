using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;

namespace backend.Data.Repository.ReservationRepository
{
    public interface IReservationRepository
    {
        // List<Reservation> GetAllReservation();

        List<Reservation>? GetListReservation(Guid? restaurantId, int? status, DateTime? date);

        void AddReservation(Reservation reservation);

        Reservation? GetReservationById(Guid reservationId);

        bool IsSaveChange();

        void ChangeReservationStatus(Reservation reservation, ReservationStatus status);
    }
}