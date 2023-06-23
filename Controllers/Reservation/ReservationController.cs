using backend.Data.Entities;
using backend.DTOs.ReservationDTO;
using backend.DTOs.ResponseDTO;
using backend.Services.ReservationService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Reservation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpGet]
        public ActionResult Get(Guid? restaurantId, int? status, DateTime? date)
        {
            var reservations = _reservationService.GetListReservation(restaurantId, status, date);
            return Ok(new SuccessResponse<List<ReservationOverviewDto>>(){
                Success = true,
                Message = "Get list reservation success",
                Data = reservations
            });
        }

        [HttpGet("{id}")]
        public ActionResult GetReservationById(Guid id)
        {
            var reservation = _reservationService.GetReservationById(id);
            if(reservation == null) {
                return NotFound(new ErrorResponse() {
                    Success = false,
                    ErrorMessage = "Reservation not found"
                });
            }
            else {
                return Ok(new SuccessResponse<ReservationDetailDto>() {
                    Success = true,
                    Message = "Get reservation successfully",
                    Data = reservation
                });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReservationDto reservationDto, Guid userId, Guid restaurantId)
        {
            _reservationService.AddReservation(reservationDto, userId, restaurantId);
            if(_reservationService.IsSaveChange()) {
                return Ok(new SuccessResponse<ReservationDto>() {
                    Success = true,
                    Message = "Create reservation successfully",
                    Data = reservationDto
                });
            }
            return BadRequest(new ErrorResponse() {
                Success = false,
                ErrorMessage = "Create reservation failed"
            });
        }

        [HttpPut("changestatus/{idReservation}")]
        public IActionResult UpdateStatusReservation(Guid idReservation, int statusId)
        {
            _reservationService.ChangeReservation(idReservation, (ReservationStatus)statusId);
            if(_reservationService.IsSaveChange()) {
                return Ok(new SuccessResponse<int>() {
                    Success = true,
                    Message = "Udpate status succes",
                    Data = statusId
                });
            }
            else {
                return BadRequest(new ErrorResponse() {
                    Success = false,
                    ErrorMessage = "Update status failed"
                });
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}