using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.ReservationDTO;

namespace backend.Services.ReservationService
{
    public interface IReservationService
    {
        List<ReservationDto> GetListReservation(Guid? restaurantId, int? status);

        void AddReservation(ReservationDto reservationDto, Guid userId, Guid restaurantId);

        bool IsSaveChange();
    }
}