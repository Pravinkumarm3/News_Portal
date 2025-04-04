using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Portal.Repository.InterfaceStructure;
using News_Portal.Repository.ServiceClasses;

namespace News_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {

        private readonly IFileModalService _fileModalService1  ;
        public FilesController(IFileModalService fileModalService)
        {
            _fileModalService1 = fileModalService;
            

        }
        [HttpPost("files")]
        public async Task<IActionResult> PostImages( IFormFile filess)
        {
            await _fileModalService1.AddImage(filess);
            return Ok("succcess");
        }
        [HttpGet("GetAllData")]
        public async Task<IActionResult> GetAllData()
        {
            var result = await _fileModalService1.GetImageList();
            return Ok(result);
        }
        [HttpDelete("DeleteData")]
        public async Task<IActionResult> DeleteData(int id)
        {
            await _fileModalService1.DeleteImage(id);
            return Ok("Sucessid");
        }

    }
}
