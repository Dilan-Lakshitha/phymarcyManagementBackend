using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;
using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            await _repository.AddAsync(supplier);
            return supplier;
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
        
        public async Task<Supplier?> UpdateSupplierAsync(int id, Supplier supplierRequest)
        {
            var existingSupplier = await _repository.GetByIdAsync(id);
            if (existingSupplier == null) return null;

            existingSupplier.supplier_name = supplierRequest.supplier_name;
            existingSupplier.supplier_contact = supplierRequest.supplier_contact;
            existingSupplier.email = supplierRequest.email;

            var result = await _repository.UpdateAsync(existingSupplier);
            return result > 0 ? existingSupplier : null;
        }
    }
}