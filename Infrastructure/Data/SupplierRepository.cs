using Dapper;
using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Infrastructure.Data
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        
        private readonly DapperContext _context;

        public SupplierRepository(IConfiguration configuration , DapperContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            var sql = "SELECT * FROM supplier";
            return await connection.QueryAsync<Supplier>(sql);
        }

        public async Task<Supplier> GetByIdAsync(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = "SELECT * FROM supplier WHERE supplier_id = @supplier_id";
            return await connection.QueryFirstOrDefaultAsync<Supplier>(sql, new { Id = id });
        }

        public async Task<int> AddAsync(Supplier supplier)
        {
            using var connection = _context.CreateConnection();
            var sql = @"INSERT INTO supplier (supplier_name, supplier_contact, email) 
                        VALUES (@supplier_name, @supplier_contact, @email)";
            return await connection.ExecuteAsync(sql, supplier);
        }

        public async Task<int> UpdateAsync(Supplier supplier)
        {
            using var connection = _context.CreateConnection();
            var sql = @"UPDATE supplier 
                        SET supplier_name = @supplier_name, ContactNumber = @supplier_contact, 
                            email = @email, 
                        WHERE supplier_id = @supplier_id";
            return await connection.ExecuteAsync(sql, supplier);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = "DELETE FROM Suppliers WHERE supplier_id = @supplier_id";
            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
