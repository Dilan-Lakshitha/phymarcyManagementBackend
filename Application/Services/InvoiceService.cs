using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepo;

        public InvoiceService(IInvoiceRepository invoiceRepo)
        {
            _invoiceRepo = invoiceRepo;
        }

        public async Task<int> CreateInvoiceAsync(InvoiceDto dto)
        {
            return await _invoiceRepo.CreateInvoiceAsync(dto);
        }
        
        public async Task<InvoiceDetailsDto> GetInvoiceByIdAsync(int invoiceId)
        {
            return await _invoiceRepo.GetInvoiceByIdAsync(invoiceId);
        }
        
        public async Task<IEnumerable<InvoiceDetailsDto>> GetLatestInvoicesAsync(int count)
        {
            return await _invoiceRepo.GetLatestInvoicesAsync(count);
        }
    }   
}