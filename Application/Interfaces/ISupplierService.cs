using phymarcyManagement.Domain.Entities;
using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier> CreateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(int id);
        
        Task<Supplier?> UpdateSupplierAsync(int id, Supplier supplierRequest);
    }   
}