using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Application.Interfaces;

public interface IUserServiceRepository
{
   Task RegisterUserAsync(string username, string email, string password);
   
   Task<string> LoginUserAsync(string username, string password);
}