using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.ResponseDTO;
using backend.Services.UploadImageService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Image
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IUploadImageService _imageService;
        public ImageController(IUploadImageService imageService)
        {
            _imageService = imageService;
            
        }
        [HttpPost]
        public async Task<ActionResult> Post(List<IFormFile> images, string typeImage, Guid userId)
        {
            var urls = new List<string>();
            for (var i = 0; i < images.Count; i++)
            {
                var url = await _imageService.UploadImage(userId.ToString(), typeImage, DateTime.Now.ToString("FFFFFFF"), images[i]);
                urls.Add(url);
            }
            return Ok(new SuccessResponse<List<string>>() {
                Success = true,
                Message = "Upload image successfully",
                Data = urls
            });
        }
    }
}