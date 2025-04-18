﻿
using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Application.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier> GetByIdAsync(int id);
        Task<int> AddAsync(Supplier supplier);
        Task<int> UpdateAsync(Supplier supplier);
        Task<int> DeleteAsync(int id);
    }   
}