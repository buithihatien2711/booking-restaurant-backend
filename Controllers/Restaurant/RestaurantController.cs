using backend.Data.Entities;
using backend.DTOs.ResponseDTO;
using backend.DTOs.RestaurantDTO;
using backend.Services.RestaurantService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Restaurant
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
            
        }
        [HttpGet("collection/{filter}")]
        public ActionResult GetListRestaurant(string? filter = null)
        {
            if(string.IsNullOrEmpty(filter)){
                return Ok(new SuccessResponse<List<RestaurantOverviewDto>>(){
                    Success = true,
                    Message = "Get list restaurant success",
                    Data = _restaurantService.GetListRestaurant("", 1)
                });
            }

            // return Ok(_restaurantService.GetListRestaurant(filter, 1));
            return Ok(new SuccessResponse<List<RestaurantOverviewDto>>(){
                    Success = true,
                    Message = "Get list restaurant success",
                    Data = _restaurantService.GetListRestaurant(filter, 1)
                });
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var restaurant = _restaurantService.GetRestaurantById(id);
            if(restaurant == null) return NotFound(
                new ErrorResponse() {
                    Success = false,
                    ErrorMessage = "Không tìm thấy nhà hàng nào"
                }
            );
            return Ok(
                new SuccessResponse<RestaurantDetailDto>(){
                    Success = true,
                    Message = "Get restaurant success",
                    Data = restaurant
                }
            );
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
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