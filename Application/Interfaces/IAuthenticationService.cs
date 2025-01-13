using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Application.Interfaces
{
    public interface IAuthenticationService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
        string GenerateToken(User user);
    }
}
