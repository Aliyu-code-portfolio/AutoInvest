using AutoInvest.Application.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace AutoInvest.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpDelete("delete-user/{Id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteRegister(id);
            return StatusCode(result.StatusCode,result);
        }

        [HttpGet("get-all-user")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _userService.GetAllRegisterUser();
            return StatusCode(result.StatusCode,result);
        }

        [HttpGet("get-user-by-id/{Id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _userService.GetRegisterUserById(id);
            return StatusCode(result.StatusCode,result);
        }

        
    }
}
