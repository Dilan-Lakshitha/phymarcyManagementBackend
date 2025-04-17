using Dapper;
using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Infrastructure.Data
{
    public class DrugRepository : IDrugRepository
    {
        private readonly DapperContext _context;

        public DrugRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Drug>> GetAllDrugsAsync()
        {
            var query = "SELECT * FROM drug";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Drug>(query);
        }

        public async Task<Drug> GetDrugByIdAsync(int id)
        {
            var query = "SELECT * FROM drug WHERE drug_id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Drug>(query, new { Id = id });
        }

        public async Task<Drug> AddDrugAsync(Drug drug)
        {
            var query = @"
                INSERT INTO drug (name, description, price, quantity, supplier_id)
                VALUES (@Name, @Description, @Price, @Quantity, @supplier_id)
                RETURNING *;
            ";
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleAsync<Drug>(query, drug);
        }

        public async Task<Drug> UpdateDrugAsync(Drug drug)
        {
            var query = @"
                UPDATE drug 
                SET name = @Name,
                    description = @Description,
                    price = @Price,
                    quantity = @Quantity,
                    supplier_id = @supplier_id
                WHERE drug_id = @DrugId
                RETURNING *;
            ";
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Drug>(query, drug);
        }

        public async Task DeleteDrugAsync(int id)
        {
            var query = "DELETE FROM drug WHERE drug_id = @Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }    
}
