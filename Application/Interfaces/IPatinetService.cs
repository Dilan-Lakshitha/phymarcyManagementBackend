using phymarcyManagement.Domain.Entities;
using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Application.Interfaces;

public interface IPatinetService
{
        Task<Patinet?> AddPatinetDataAsync(PatinetRegister patientName);
        
}