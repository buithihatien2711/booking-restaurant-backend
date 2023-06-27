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
    public class ExtraServiceController : ControllerBase
    {
        private readonly IExtraServiceService _extraServiceService;
        private readonly IMapper _mapper;

        public ExtraServiceController(IExtraServiceService extraServiceService, IMapper mapper)
        {
            _extraServiceService = extraServiceService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var extraServices = _extraServiceService.GetAllExtraService();
            return Ok (new SuccessResponse<List<ExtraServiceDto>>() {
                Success = true,
                Message = "Get list extra service successfully",
                Data = extraServices
            });
        }

        [HttpGet("{idRestaurant}")]
        public ActionResult GetListExtraServiceOfRestaurant(Guid idRestaurant)
        {
            return Ok(
                new SuccessResponse<List<ExtraServiceDto>>(){
                    Success = true,
                    Message = "get list extra service successfully",
                    Data = _extraServiceService.GetExtraServiceOfRestaurant(idRestaurant)
                }
            );
        }
    }
}