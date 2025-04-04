using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Portal.ModelsDto;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Politics_NewsController : ControllerBase
    {
        private readonly IPolitics_NewsService _newsService;
        public Politics_NewsController(IPolitics_NewsService _newsService)
        {
            this._newsService = _newsService;
            
        }
        [HttpGet("GetAllData")]
        public async Task <IActionResult> GetAllData()
        {
           var result= await _newsService.GetPoliticsNews();
            return Ok(result);    

        }
        [HttpPost("PostNews")]
        public async Task< IActionResult> PostNews(Politics_NewsDto _NewsDto)
        {
            await _newsService.Post(_NewsDto);
            return Ok("Data is Post successfuly");
        }
        [HttpDelete("DeleteData")]
        public async Task< IActionResult> DeleteNews(int id)
        {
            await _newsService.Delete(id);
            return Ok("Data is Deleted successfuly");

        }
        [HttpPut("UpdatedData")]
        public async Task <IActionResult> UpdatedData(Politics_NewsDto _NewsDto)
        {
            await _newsService.UpdateNews(_NewsDto);
            return Ok("Data is Updated successfuly");
        }
    }
}
