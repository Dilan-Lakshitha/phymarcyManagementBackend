using Microsoft.AspNetCore.Mvc;
using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugController : ControllerBase
    {
        private readonly IDrugService _drugService;

        public DrugController(IDrugService drugService)
        {
            _drugService = drugService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _drugService.GetAllDrugsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var drug = await _drugService.GetDrugByIdAsync(id);
            if (drug == null) return NotFound();
            return Ok(drug);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Drug drug)
        {
            var newDrug = await _drugService.AddDrugAsync(drug);
            return CreatedAtAction(nameof(Get), new { id = newDrug.drug_id }, newDrug);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Drug drug)
        {
            if (id != drug.drug_id) return BadRequest();
            var updated = await _drugService.UpdateDrugAsync(drug);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _drugService.DeleteDrugAsync(id);
            return NoContent();
        }
    }
}