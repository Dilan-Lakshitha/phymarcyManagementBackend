using Dapper;
using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Infrastructure.Data
{
    public class PatinetRepository : IPatinetRepository
    {
        private readonly DapperContext _context;

        public PatinetRepository(DapperContext context)
        {
            _context = context;
        }
        
        public async Task<Patinet?> GetPatinetByPatinetAsync(int customerId)
        {
             var query = "SELECT * FROM public.customer WHERE customer_id = @customer_id";
             using var connection = _context.CreateConnection();
             return await connection.QueryFirstOrDefaultAsync<Patinet>(query, new { customer_id = customerId });
         }
        
        public async Task<List<Patinet>> GetPatinetsAsync() 
        {
            using var connection = _context.CreateConnection();
            var query = "SELECT * FROM public.customer";
            var Patinet = await connection.QueryAsync<Patinet>(query);
            
            return  Patinet.ToList();
        }

        public async Task<Patinet> AddPatinetAsync(Patinet patinet)
        {
            using var connection = _context.CreateConnection();
            var query = "INSERT INTO public.customer (customer_name , customer_age, customer_contact) VALUES (@customer_name, @customer_age, @customer_contact) RETURNING *";
            var insertedPatinet = await connection.QuerySingleAsync<Patinet>(query, patinet);
            
            return  insertedPatinet;
        }
        
        public async Task<Patinet> UpdatePatinetAsync(Patinet patinet)
        {
            using var connection = _context.CreateConnection();
            var query = @"UPDATE public.customer 
                  SET customer_name = @customer_name, 
                      customer_age = @customer_age, 
                      customer_contact = @customer_contact 
                  WHERE customer_id = @customer_id 
                  RETURNING *";

            return await connection.QuerySingleOrDefaultAsync<Patinet>(query, patinet);
        }

        public async Task<bool> DeletePatinetAsync(int customerId)
        {
            using var connection = _context.CreateConnection();
            var query = "DELETE FROM public.customer WHERE customer_id = @customer_id";
            var affectedRows = await connection.ExecuteAsync(query, new { customer_id = customerId });
            return affectedRows > 0;
        }
    }
}
