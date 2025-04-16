using Microsoft.AspNetCore.Mvc;
using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;
using phymarcyManagement.Models.DTOs;

namespace PharmacyManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost("supplierCreate")]
        public async Task<IActionResult> SupplierRegister([FromBody] Supplier supplier)
        {
            var result = await _supplierService.CreateSupplierAsync(supplier);
            return Ok(result);
        }

        [HttpGet("supplierList")]
        public async Task<IActionResult> Suppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            return Ok(suppliers);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SupplierDelete(int id)
        {
            var deleted = await _supplierService.DeleteSupplierAsync(id);
            if (!deleted)
                return NotFound("Supplier not found");
            return Ok("Deleted successfully");
        }
        
        [HttpPut("updateSupplier/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] Supplier supplier)
        {
            var updatedPatient = await _supplierService.UpdateSupplierAsync(id, supplier);
            if (updatedPatient == null)
                return NotFound("Supplier not found");

            return Ok(updatedPatient);
        }
    }
}