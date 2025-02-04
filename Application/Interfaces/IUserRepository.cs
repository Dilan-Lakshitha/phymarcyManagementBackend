using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<PharmacyUser?> GetUserByUsernameAsync(string pharmaUsername);
        Task AddUserAsync(PharmacyUser pharmacyUser);
    }
}

