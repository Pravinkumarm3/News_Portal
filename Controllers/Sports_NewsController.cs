using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Portal.ModelsDto;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sports_NewsController : ControllerBase
    {
        private readonly ISports_NewsService _newsService;
        public Sports_NewsController(ISports_NewsService _newsService )
        {
            this._newsService = _newsService;            
        }
        [HttpGet("GetNewsData")]
        public async Task <IActionResult> GetNewsData()
        {
           var rest = await _newsService.GetAllNews();
            return Ok(rest);

        }
        [HttpPost("PostNewsData")]
        public async Task<IActionResult> PostNewsData(Sports_NewsDto sports_NewsDto)
        {
            await _newsService.PostData(sports_NewsDto);
            return Ok("Data is Posted successfuly");
        }
        [HttpPut("DataUpdated")]
        public async Task <IActionResult> DataUpdated(Sports_NewsDto sports_)
        {
            await _newsService.UpdateNews(sports_);
            return Ok("Data is Updated successfuly");
        }
        [HttpDelete("DataDeleted")]
        public async Task <IActionResult> DataDeleted(int id)
        {
            await _newsService.DeleteData(id);
            return Ok("Data is Deleted successfuly");

        }
    }
}
