using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DTOs.ResponseDTO;
using backend.DTOs.RestaurantDTO;
using backend.Services.RestaurantService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Restaurant
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServiceController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }
        [HttpGet]
        public ActionResult<List<ServiceDto>> GetAllService()
        {
            return Ok(
                new SuccessResponse<List<ServiceDto>>(){
                    Success = true,
                    Message = "get list service success",
                    Data = _servicesService.GetAllService()
                }
            );
        }

        [HttpGet("{restaurantId}")]
        public ActionResult<List<ServiceDto>> GetServicesOfRestaurant(Guid restaurantId)
        {
            return Ok(
                new SuccessResponse<List<ServiceDto>>(){
                    Success = true,
                    Message = "get list service success",
                    Data = _servicesService.GetServiceOfRestaurant(restaurantId)
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