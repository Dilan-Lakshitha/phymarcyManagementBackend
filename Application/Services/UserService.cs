using Microsoft.AspNetCore.Authentication;
using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;
using System;
using System.Threading.Tasks;
using IAuthenticationService = phymarcyManagement.Application.Interfaces.IAuthenticationService;


namespace phymarcyManagement.Application.Services
{
    public class UserService : IUserServiceRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authService;

        public UserService(IUserRepository userRepository, IAuthenticationService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task RegisterUserAsync(string PharmacyName,string email, string password)
        {
            var hashPassword = _authService.HashPassword(password);
            var pharmacyUser = new PharmacyUser
            {
                PharmacyName = PharmacyName,
                Email = email,
                Password = hashPassword
            };

            await _userRepository.AddUserAsync(pharmacyUser);
        }
        public async Task<string> LoginUserAsync(string PharmacyUser,string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(PharmacyUser);
            if (user == null)
            {
                Console.WriteLine("User not found: " + PharmacyUser);
                throw new UnauthorizedAccessException("Invalid username");
            }

            // Verify password
            if (!_authService.VerifyPassword(password, user.Password))
            {
                Console.WriteLine("Password mismatch for user: " + PharmacyUser);
                throw new UnauthorizedAccessException("Invalid password.");
            }

            // Generate token
            return _authService.GenerateToken(user);
        }
    }
}
