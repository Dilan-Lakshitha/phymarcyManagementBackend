using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Application.Interfaces;

public interface IPatinetRepository
{
    Task<Patinet?> GetPatinetByPatinetAsync(int patinetId);
    
    Task <Patinet>AddPatinetAsync(Patinet patinet);
}