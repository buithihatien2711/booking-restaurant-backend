using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Entities;
using backend.DTOs.ReservationDTO;

namespace backend.Services.ReservationService
{
    public interface IReservationService
    {
        List<ReservationOverviewDto>? GetListReservation(Guid? restaurantId, int? status, DateTime? date);
        void AddReservation(ReservationDto reservationDto, Guid userId, Guid restaurantId);
        ReservationDetailDto? GetReservationById(Guid reservationId);
        bool IsSaveChange();
        void ChangeReservation(Guid reservationId, ReservationStatus status);
    }
}