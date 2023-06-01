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
            return _cuisineService.GetAllCuisine();
        }

        [HttpGet("{idRestaurant}")]
        public ActionResult<List<CuisineDto>> GetCuisinesOfRestaurant(Guid idRestaurant)
        {
            return _cuisineService.GetCuisineOfRestaurant(idRestaurant);
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