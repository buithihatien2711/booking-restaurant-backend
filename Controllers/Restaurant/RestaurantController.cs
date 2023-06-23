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
        [HttpGet("collection/{filter}/{page}")]
        public ActionResult GetListRestaurant(string? filter, int page)
        {
            if(string.IsNullOrEmpty(filter)){
                return Ok(new SuccessResponse<List<RestaurantOverviewDto>>(){
                    Success = true,
                    Message = "Get list restaurant success",
                    Data = _restaurantService.GetListRestaurant("", page)
                });
            }

            // return Ok(_restaurantService.GetListRestaurant(filter, 1));
            return Ok(new SuccessResponse<List<RestaurantOverviewDto>>(){
                    Success = true,
                    Message = "Get list restaurant success",
                    Data = _restaurantService.GetListRestaurant(filter, page)
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

        [HttpGet("user/{id}")]
        public ActionResult GetRestaurantIdByUser(Guid id)
        {
            var idRestaurant =  _restaurantService.GetRestaurantIdByUser(id);
            if(idRestaurant == null) {
                return NotFound(new ErrorResponse(){
                    Success = false,
                    ErrorMessage = "Restaurant not found"
                });
            }
            else {
                return Ok(new SuccessResponse<Guid>() {
                    Success = true,
                    Message =  "Get restaurant id successfully",
                    Data = idRestaurant.Value
                });
            }
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