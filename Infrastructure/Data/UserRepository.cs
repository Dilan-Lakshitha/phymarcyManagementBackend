using Dapper;
using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;
using static phymarcyManagement.Infrastructure.Data.UserRepository;

namespace phymarcyManagement.Infrastructure.Data
{
    public class UserRepository: IUserRepository
    {
        private readonly DapperContext _context;
        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<PharmacyUser> GetUserByUsernameAsync(string pharmacyUsername)
        {
            var query = "SELECT * FROM public.pharmacy WHERE pharmacyname = @pharmacyUsername";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<PharmacyUser>(query, new { pharmacyUsername = pharmacyUsername });
        }


        public async Task AddUserAsync(PharmacyUser pharmacyUser)
        {
            var query = "INSERT INTO public.pharmacy (pharmacyname , email, password) VALUES (@PharmacyName, @Email, @Password)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, pharmacyUser);
        }
    }
}
