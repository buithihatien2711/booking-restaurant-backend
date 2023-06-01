using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return _suitabilityService.GetAllSuitability();
        }

        [HttpGet("{idRestaurant}")]
        public ActionResult<List<SuitabilityDto>?> GetSuitablityOfService(Guid idRestaurant)
        {
            return _suitabilityService.GetSuitabilityOfRestaurant(idRestaurant);
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