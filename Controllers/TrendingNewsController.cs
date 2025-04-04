using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Portal.ModelsDto;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class TrendingNewsController : ControllerBase
    {
        private readonly ITrending_NewsServices _trending_NewsServices;
        public TrendingNewsController(ITrending_NewsServices trending_NewsServices)
        {
            _trending_NewsServices = trending_NewsServices;
        }
        [HttpPost("AddTrending")]
         public async Task <IActionResult> TrendingNews(Trending_NewsDto trending_NewsDto)
        {
            await _trending_NewsServices.Addtrending(trending_NewsDto);
            return Ok("User Register successful");
        }
        [HttpGet("GetTrendings")]
        public async Task<IActionResult> GetTending()
        {
            var result = await _trending_NewsServices.Gettrending();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _trending_NewsServices.GetTrendingNews(id);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("UpdateData")]
        public async Task<IActionResult>UpdateData(Trending_NewsDto trending_NewsDto)
        {
            await _trending_NewsServices.UpdateTrendind(trending_NewsDto);
            return Ok("Updated successful");
        }
        [HttpDelete("DeleteData")]
        public async Task<IActionResult>DeleteData(int id)
        {
            await _trending_NewsServices.DeleteProduct( id);
            return Ok("Delete Data successful");
        }

    }
}
