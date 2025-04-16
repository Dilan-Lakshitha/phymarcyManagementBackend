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
            var hashPassword = _authService.HashPassword(pharmacyRegisterRequest.password);
            var pharmacyUser = new PharmacyUser
            {
                pharmacy_name = pharmacyRegisterRequest.Pharmacy_name,
                pharmacy_email = pharmacyRegisterRequest.pharmacy_email,
                password = hashPassword,
                location = pharmacyRegisterRequest.location
            };

            await _userRepository.AddUserAsync(pharmacyUser);
        }
        public async Task<string> LoginUserAsync(LoginRequest loginRequest)
        {
            var user = await _userRepository.GetUserByUsernameAsync(loginRequest.Pharmarcy_name);
            if (user == null)
            {
                Console.WriteLine("User not found: " + loginRequest.Pharmarcy_name);
                throw new UnauthorizedAccessException("Invalid username");
            }

            // Verify password
            if (!_authService.VerifyPassword(loginRequest.Password, user.password))
            {
                Console.WriteLine("Password mismatch for user: " + loginRequest.Pharmarcy_name);
                throw new UnauthorizedAccessException("Invalid password.");
            }

            // Generate token
            return _authService.GenerateToken(user);
        }
    }
}
