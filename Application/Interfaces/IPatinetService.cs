using phymarcyManagement.Domain.Entities;
using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Application.Interfaces;

public interface IPatinetService
{
        Task<Patinet?> AddPatinetDataAsync(PatinetRegister patientName);
        
        Task<List<Patinet>> GetPatinetsDataAsync();
        
        Task<Patinet?> UpdatePatientAsync(int id, PatinetRegister patinetRequest);
        Task<int?> DeletePatientAsync(int id);


}