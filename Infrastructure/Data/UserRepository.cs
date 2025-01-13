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

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var query = "SELECT * FROM public.user WHERE username = @username";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(query, new { Username = username });
        }


        public async Task AddUserAsync(User user)
        {
            var query = "INSERT INTO public.user (username , email, password) VALUES (@Username, @Email, @Password)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, user);
        }
    }
}
