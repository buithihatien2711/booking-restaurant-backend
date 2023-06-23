using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data.Entities;
using backend.Data.Repository.ReservationRepository;
using backend.DTOs.ReservationDTO;

namespace backend.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public void AddReservation(ReservationDto reservationDto, Guid userId, Guid restaurantId)
        {
            var reservation = new Reservation()
            {
                Id = new Guid(),
                NumAdults = reservationDto.NumAdults,
                NumChildren = reservationDto.NumChildren,
                Note = reservationDto.Note,
                CreateAt = DateTime.Now,
                UserId = userId,
                RestaurantId = restaurantId,
                ReservationStatus = ReservationStatus.Waiting,
                NameCustomer = reservationDto.NameCustomer,
                PhoneCustomer = reservationDto.PhoneCustomer,

                // handle
                Time = reservationDto.Time
            };
            _reservationRepository.AddReservation(reservation);
        }

        public void ChangeReservation(Guid reservationId, ReservationStatus status)
        {
            var reservation = _reservationRepository.GetReservationById(reservationId);
            if(reservation == null) return;
            _reservationRepository.ChangeReservationStatus(reservation, status);
        }

        public List<ReservationOverviewDto>? GetListReservation(Guid? restaurantId, int? status, DateTime? date)
        {
            var reservations = _reservationRepository.GetListReservation(restaurantId, status, date);
            if(reservations == null) return null;
            return _mapper.Map<List<Reservation>, List<ReservationOverviewDto>>(reservations);
        }

        public ReservationDetailDto? GetReservationById(Guid reservationId)
        {
            var reservation = _reservationRepository.GetReservationById(reservationId);
            if(reservation == null) return null;
            return _mapper.Map<Reservation, ReservationDetailDto>(reservation);
        }

        public bool IsSaveChange()
        {
            return _reservationRepository.IsSaveChange();
        }
    }
}