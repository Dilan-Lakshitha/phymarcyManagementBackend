using Microsoft.AspNetCore.Mvc;
using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice(InvoiceDto dto)
        {
            try
            {
                var invoiceId = await _invoiceService.CreateInvoiceAsync(dto);
                return Ok(new { invoiceId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        
        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetInvoice(int invoiceId)
        {
            try
            {
                var invoice = await _invoiceService.GetInvoiceByIdAsync(invoiceId);
                if (invoice == null) return NotFound();

                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
