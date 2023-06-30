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

        [HttpGet("filter")]
        public ActionResult FilterRestaurant([FromQuery]FilterRestaurantDto filter, int pageIndex = 1)
        {
            var (restaurants, totalPage) = _restaurantService.FilterRestaurant(filter, pageIndex);
            return Ok(new SuccessResponse<ResponseList<RestaurantOverviewDto>>() {
                Success = true,
                Message = "Get list restaurant successfully",
                Data = new ResponseList<RestaurantOverviewDto>()
                {
                    Data = restaurants,
                    TotalPage = totalPage,
                }
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
        public ActionResult Post(RestaurantAddDto restaurant, Guid userId)
        {
             _restaurantService.AddRestaurant(restaurant, userId);
            // await Task.Run(() =>
            // {
            //     _restaurantService.AddRestaurant(restaurant, userId);
            // });
            if(_restaurantService.IsSaveChange()) {
                return Ok(new SuccessResponse<string>() {
                    Success = true,
                    Message = "Add restaurant successfully",
                    Data = "Success"
                });
            }
            return BadRequest(new ErrorResponse() {
                Success = false,
                ErrorMessage = "Add restaurant failed"
            });
        }

        [HttpGet("admin/restaurants/{pageIndex}")]
        public ActionResult<string> GetListRestaurantAdmin(int pageIndex, int? status)
        {
            var restaurants = new List<RestaurantAdminDto>();
            int totalPage;
            (restaurants, totalPage) = _restaurantService.GetListRestaurantAdmin(pageIndex, status);
            return Ok(new SuccessResponse<ResponseList<RestaurantAdminDto>>() {
                Success = true,
                Message = "Get list restaurant successfully",
                Data = new ResponseList<RestaurantAdminDto>() {
                    Data = restaurants,
                    TotalPage = totalPage
                }
            });
        }

        [HttpPut("changeStatus/{restaurantId}")]
        public ActionResult Put(Guid restaurantId, int status)
        {
            _restaurantService.ChangeRestaurantStatus(restaurantId, (RestaurantStatus)status);
            if(_restaurantService.IsSaveChange()) {
                return Ok(new SuccessResponse<int>() {
                    Success = true,
                    Message = "Thay đổi trạng thái thành công",
                    Data = status
                });
            }
            else {
                return BadRequest(new ErrorResponse() {
                    Success = false,
                    ErrorMessage = "Thay đổi trạng thái thất bại"
                });
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}