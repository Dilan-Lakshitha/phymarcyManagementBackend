using phymarcyManagement.Domain.Entities;
using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Application.Interfaces;

public interface IUserService
{
   Task RegisterUserAsync(PharmacyRegisterRequest pharmacyRegisterRequest);
   
   Task<string> LoginUserAsync(LoginRequest loginRequest);
}