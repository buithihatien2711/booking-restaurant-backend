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
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}