using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Portal.ModelsDto;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bollywood_NewsController : ControllerBase
    {
        private readonly IBollywood_NewsService _newsService;
        public Bollywood_NewsController(IBollywood_NewsService newsService)
        {
            this._newsService = newsService;
        }
        [HttpGet("GetData")]
        public async Task <IActionResult> GetData()
        {
            var rest=await _newsService.GetBollywoodNews();
            return Ok(rest);
        }
        [HttpPost("PostData")]
        public async Task<IActionResult> PostData(Bollywood_NewsDto bollywood_News)
        {
            await _newsService.post(bollywood_News);
            return Ok("Data is Posted successfuly");
        }
        [HttpPut("UpdateData")]
        public async Task<IActionResult> UpdateData(Bollywood_NewsDto bollywood_)
        {
            await _newsService.Update(bollywood_);
            return Ok("Data is Updated successfuly");
        }
        [HttpDelete("Deletedata")]
        public async Task<IActionResult> Deletedata(int id)
        {
            await _newsService.Delete(id);
            return Ok("Data is Deleted successfuly");
        }
    }
}
