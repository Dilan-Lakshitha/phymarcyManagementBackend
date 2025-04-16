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
        
        [HttpGet("patients")]
        public async Task<IActionResult> PatinetList()
        {
            var returnaddPatinet = await _patinetService.GetPatinetsDataAsync();
            
            return Ok(returnaddPatinet);
        }
        
        [HttpPut("updatePatient/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatinetRegister patinet)
        {
            var updatedPatient = await _patinetService.UpdatePatientAsync(id, patinet);
            if (updatedPatient == null)
                return NotFound("Patient not found");

            return Ok(updatedPatient);
        }

        [HttpDelete("deletePatinet/{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var deletedId = await _patinetService.DeletePatientAsync(id);
            if (deletedId == null)
                return NotFound("Patient not found or already deleted");

            return Ok(new { deletedCustomerId = deletedId });
        }

    }
}
