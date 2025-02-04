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
        private readonly IUserServiceRepository _userService;

        public AuthController(IUserServiceRepository userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PharmacyRegisterRequest request)
        {
            await _userService.RegisterUserAsync(request.PharmacyName, request.Email, request.Password);
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _userService.LoginUserAsync(request.PharmarcyName,request.Password);
            return Ok(new { Token = token });
        }
    }
}
