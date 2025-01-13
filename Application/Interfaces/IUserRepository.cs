using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
    }
}

