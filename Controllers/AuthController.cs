using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Application.Services;
using phymarcyManagement.Models.DTOs;
using LoginRequest = phymarcyManagement.Models.DTOs.LoginRequest;

namespace phymarcyManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PharmacyRegisterRequest request)
        {
            await _userService.RegisterUserAsync(request);
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _userService.LoginUserAsync(request);
            return Ok(new { Token = token });
        }
    }
}
