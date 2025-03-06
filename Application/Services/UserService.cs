using Microsoft.AspNetCore.Authentication;
using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;
using System;
using System.Threading.Tasks;
using phymarcyManagement.Models.DTOs;
using IAuthenticationService = phymarcyManagement.Application.Interfaces.IAuthenticationService;


namespace phymarcyManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authService;

        public UserService(IUserRepository userRepository, IAuthenticationService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task RegisterUserAsync(PharmacyRegisterRequest pharmacyRegisterRequest)
        {
            var hashPassword = _authService.HashPassword(pharmacyRegisterRequest.Password);
            var pharmacyUser = new PharmacyUser
            {
                PharmacyName = pharmacyRegisterRequest.PharmacyName,
                Email = pharmacyRegisterRequest.Email,
                Password = hashPassword
            };

            await _userRepository.AddUserAsync(pharmacyUser);
        }
        public async Task<string> LoginUserAsync(LoginRequest loginRequest)
        {
            var user = await _userRepository.GetUserByUsernameAsync(loginRequest.PharmarcyName);
            if (user == null)
            {
                Console.WriteLine("User not found: " + loginRequest.PharmarcyName);
                throw new UnauthorizedAccessException("Invalid username");
            }

            // Verify password
            if (!_authService.VerifyPassword(loginRequest.Password, user.Password))
            {
                Console.WriteLine("Password mismatch for user: " + loginRequest.PharmarcyName);
                throw new UnauthorizedAccessException("Invalid password.");
            }

            // Generate token
            return _authService.GenerateToken(user);
        }
    }
}
