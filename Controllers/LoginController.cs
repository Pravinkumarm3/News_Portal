using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Portal.ModelsDtos;
using News_Portal.Repository.InterfaceStructure;

namespace News_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //private readonly ILoginService _loginService;

        //public LoginController(ILoginService loginService)
        //{
        //    _loginService = loginService;
        //}
        //[HttpPost("register")]
        //public async Task<IActionResult> Register(UserDtos userDto)
        //{
        //    var response = await _loginService.Register(userDto);
        //    if (response.Message.Contains("already exists"))
        //    {
        //        return BadRequest(response);
        //    }
        //    return Ok(response);
        //}
        //[HttpPost("login")]
        //public async Task<IActionResult> Login(LoginDtos loginDto)
        //{
        //    var response = await _loginService.Login(loginDto);
        //    if (response.Message.Contains("Invalid"))
        //    {
        //        return Unauthorized(response);
        //    }
        //    return Ok(response);
        //}
    }
}
