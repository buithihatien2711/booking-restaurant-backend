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
                ReservationStatus = ReservationStatus.Booked,
                NameCustomer = reservationDto.NameCustomer,
                PhoneCustomer = reservationDto.PhoneCustomer,

                // handle
                Time = reservationDto.Time
            };
            _reservationRepository.AddReservation(reservation);
        }

        public List<ReservationDto> GetListReservation(Guid? restaurantId, int? status)
        {
            throw new NotImplementedException();
        }

        public bool IsSaveChange()
        {
            return _reservationRepository.IsSaveChange();
        }
    }
}