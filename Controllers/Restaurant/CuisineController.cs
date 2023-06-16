using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.ResponseDTO;
using backend.DTOs.RestaurantDTO;
using backend.Services.RestaurantService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Restaurant
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineController : ControllerBase
    {
        private readonly ICuisineService _cuisineService;

        public CuisineController(ICuisineService cuisineService)
        {
            _cuisineService = cuisineService;
        }
        [HttpGet]
        public ActionResult<List<CuisineDto>> GetAllCuisine()
        {
            return Ok(
                new SuccessResponse<List<CuisineDto>>(){
                    Success = true,
                    Message = "get list cuisine success",
                    Data = _cuisineService.GetAllCuisine()
                }
            );
        }

        [HttpGet("{idRestaurant}")]
        public ActionResult<List<CuisineDto>> GetCuisinesOfRestaurant(Guid idRestaurant)
        {
            return Ok(
                new SuccessResponse<List<CuisineDto>>(){
                    Success = true,
                    Message = "get list cuisine success",
                    Data = _cuisineService.GetCuisineOfRestaurant(idRestaurant)
                }
            );
        }
    }
}