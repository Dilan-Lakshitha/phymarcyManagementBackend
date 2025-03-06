using Microsoft.AspNetCore.Mvc;
using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Controllers 
{
    [Route("api/[controller]")]
    [ApiController] 
    public class PatinetController : ControllerBase 
    {
        private readonly IPatinetService _patinetService;
        
        public PatinetController(IPatinetService patinetService)
        {
            _patinetService = patinetService;
        }

        [HttpPost("patinetRegister")]
        public async Task<IActionResult> PatinetRegister([FromBody] PatinetRegister patinet)
        {
            var returnaddPatinet = await _patinetService.AddPatinetDataAsync(patinet);
            return Ok(returnaddPatinet);
        }
    }
}
