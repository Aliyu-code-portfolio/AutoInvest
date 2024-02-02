using AutoInvest.Application.Abstraction;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.Util;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoInvest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST api/<AuthController>
        [HttpPost("sign-up")]
        public async Task<IActionResult> Signup([FromBody] RegisterUserDto registerUserDto)
        {
            var result = await _authService.RegisterUser(registerUserDto, Request);
            return StatusCode(result.StatusCode, result);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var result = await _authService.LoginUser(loginRequestDto);
            return StatusCode(result.StatusCode, result);
        }


        // PUT api/<AuthController>/5
        [HttpGet("confirm-email/{email}/{token}")]
        public async Task<ContentResult> ConfirmEmail(string email, string token)
        {
            var result = await _authService.ConfirmEmail(email, token);
            return result.Success ? new ContentResult
            {
                Content = EmailSuccessLogo.htmlVerified,
                ContentType = "text/html"
            } :
             new ContentResult
             {
                 Content = EmailSuccessLogo.htmlFailed,
                 ContentType = "text/html"
             };
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
