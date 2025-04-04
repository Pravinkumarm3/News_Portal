using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Portal.ModelsDto;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Business_NewsController : ControllerBase
    {
        private readonly IBusiness_NewsService businessnews_service;
        public Business_NewsController(IBusiness_NewsService businessnews_service)
        {
            this.businessnews_service = businessnews_service;            
        }
        [HttpGet("GetBusiness")]
        public async Task<IActionResult> GetBusiness(string newstype)
        {

            var rest=await businessnews_service.GetBusinessNews(newstype);
            return Ok(rest);
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetBusiness()
         {

            var rest = await businessnews_service.GetBusinessNews();
            return Ok(rest);
        }
        [HttpPost("PostData")]
        public async Task<IActionResult> PostData(Business_NewsDto _NewsDto)
        {
            await businessnews_service.Post(_NewsDto);
            return Ok("Data is Posted successfuly");
        }
        [HttpPut("UpdateData")]
        public async Task<IActionResult> UpdateData(Business_NewsDto business_)
        {
            await businessnews_service.UpdateNews(business_);
            return Ok("Data is Updated successfuly");
        }
        [HttpDelete("DeleteData")]
        public async Task<IActionResult> DeleteData(int id)
        {
            await businessnews_service.Delete(id);
            return Ok("Data is daleted successfuly");
        }
    }
}
