using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Application.Interfaces;

public interface IUserServiceRepository
{
   Task RegisterUserAsync(string pharmacyusername, string email, string password);
   
   Task<string> LoginUserAsync(string pharmacyusername, string password);
}