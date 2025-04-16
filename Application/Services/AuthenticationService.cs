using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;         
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace phymarcyManagement.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public string GenerateToken(PharmacyUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("uM8hGt47yQpLwD3cN5zTfR1vXsK9Ab2J");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim("id", user.pharmacy_id.ToString()),
                    new Claim("PharmarcyName", user.pharmacy_name),
                    new Claim(ClaimTypes.Email, user.pharmacy_email)
                ]),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
