using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Portal.ModelsDtos;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ImageUploadedController : ControllerBase
    {
        private readonly IMultiplePhotoService _multiplePhotoService;
        public ImageUploadedController(IMultiplePhotoService multiplePhotoService)
        {
            _multiplePhotoService = multiplePhotoService;
            
        }
        [HttpPost("PostAllData")]
        public async Task<IActionResult>PostImages([FromForm] IFormFile[] filess, [FromForm] int trendingId)
        {
            await _multiplePhotoService.AddImage(filess, trendingId);
            return Ok("succcess");
        }
        [HttpGet("GetAllData")]
        public async Task<IActionResult> GetAllData()
        {
            var result=await _multiplePhotoService.GetImageList();
            return Ok(result);
        }
        [HttpDelete("DeleteData")]
        public async Task<IActionResult> DeleteData(int id)
        {
            await _multiplePhotoService.DeleteImage(id);
            return Ok("Sucessid");
        }
        [HttpPut("UpdateData")]
        public async Task<IActionResult> UpdateData([FromForm] IFormFile[] files, [FromForm] MultiplePhotoUploaddto model)
        {
            await _multiplePhotoService.UpdateImage(files, model);
            return Ok("Updated");
        }
    }
}
