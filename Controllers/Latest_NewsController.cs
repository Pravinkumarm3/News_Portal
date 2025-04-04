using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Portal.ModelsDtos;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class Latest_NewsController : ControllerBase
    {
        private readonly ILatest_NewsServices _NewsServices;
        public Latest_NewsController(ILatest_NewsServices latest_News)
        {
            _NewsServices = latest_News;
            
        }
        [HttpGet("GetAllData")]
        public async Task<IActionResult> GetAllData()
        {
           var result=await _NewsServices.GetAllNews();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _NewsServices.GetLatestNews(id);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("PostData")]
        public async Task<IActionResult> PostData(Latest_NewsDtos _NewsDtos)
        {
             await _NewsServices.Add(_NewsDtos);
            return Ok("Data is Post Sucessesfully");
        }
        [HttpPut("UpdateData")]
        public async Task<IActionResult> UpdateData(Latest_NewsDtos NewsDtos)
        {
           await _NewsServices.UpdateNews(NewsDtos);
            return Ok("Data Updated");
        }
        [HttpDelete("DeleteData")]
        public async Task<IActionResult> DeleteData(int id)
        {
            await _NewsServices.DeleteNews(id);
            return Ok("Data Deleted");
        }
    }
}
