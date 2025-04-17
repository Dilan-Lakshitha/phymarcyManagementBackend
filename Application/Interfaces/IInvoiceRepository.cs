using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Application.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<int> CreateInvoiceAsync(InvoiceDto invoiceDto);
        
        Task<InvoiceDetailsDto> GetInvoiceByIdAsync(int invoiceId);
    }   
}