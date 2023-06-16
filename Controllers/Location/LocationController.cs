using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.LocationDTO;
using backend.DTOs.ResponseDTO;
using backend.Services.LocationService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Location
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
            
        }
        [HttpGet("cities")]
        public ActionResult GetAllCity()
        {
            var cities = _locationService.GetAllCity();
            return Ok(new SuccessResponse<List<CityDto>>(){
                Success = true,
                Message = "Get cities success",
                Data = cities
            });
        }

        [HttpGet("cities/{id}")]
        public ActionResult GetDistrictOfCity(int id)
        {
            var districts = _locationService.GetDistrictsOfCity(id);
            return Ok(new SuccessResponse<List<DistrictDto>>(){
                Success = true,
                Message = "Get list district success",
                Data = districts
            });
        }

        [HttpGet("districts/{id}")]
        public ActionResult GetWardOfDistrict(int id)
        {
            var wards = _locationService.GetWardsOfDistrict(id);
            return Ok(new SuccessResponse<List<WardDto>>(){
                Success = true,
                Message = "Get list ward success",
                Data = wards
            });
        }
    }
}