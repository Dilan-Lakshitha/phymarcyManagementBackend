using phymarcyManagement.Domain.Entities;
using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Application.Interfaces;

public interface IPatinetRepository
{
    Task<Patinet?> GetPatinetByPatinetAsync(int patinetId);
    
    Task<List<Patinet?>> GetPatinetsAsync();
    
    Task <Patinet>AddPatinetAsync(Patinet patinet);
    
    Task<Patinet> UpdatePatinetAsync(Patinet patinet);
    Task<bool> DeletePatinetAsync(int customerId);


}