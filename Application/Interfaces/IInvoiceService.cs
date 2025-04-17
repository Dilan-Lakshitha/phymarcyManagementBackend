using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Application.Interfaces;

public interface IInvoiceService
{
    Task<int> CreateInvoiceAsync(InvoiceDto dto);
    
    Task<InvoiceDetailsDto> GetInvoiceByIdAsync(int invoiceId);
}