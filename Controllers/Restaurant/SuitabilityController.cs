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
    public class SuitabilityController : ControllerBase
    {
        private readonly ISuitabilityService _suitabilityService;
        public SuitabilityController(ISuitabilityService suitabilityService)
        {
            _suitabilityService = suitabilityService;
            
        }
        [HttpGet]
        public ActionResult<List<SuitabilityDto>> GetAllSuitability()
        {
            return Ok(
                new SuccessResponse<List<SuitabilityDto>>(){
                    Success = true,
                    Message = "get list suitability success",
                    Data = _suitabilityService.GetAllSuitability()
                }
            );
        }

        [HttpGet("{idRestaurant}")]
        public ActionResult<List<SuitabilityDto>?> GetSuitablityOfService(Guid idRestaurant)
        {
            return Ok(
                new SuccessResponse<List<SuitabilityDto>>(){
                    Success = true,
                    Message = "get list suitability success",
                    Data = _suitabilityService.GetSuitabilityOfRestaurant(idRestaurant)
                }
            );
        }
    }
}