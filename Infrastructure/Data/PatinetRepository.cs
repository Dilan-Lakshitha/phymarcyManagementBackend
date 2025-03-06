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
        
        public async Task<Patinet?> GetPatinetByPatinetAsync(int patinetId)
        {
             var query = "SELECT * FROM public.patient WHERE patinetid = @patinetId";
             using var connection = _context.CreateConnection();
             return await connection.QueryFirstOrDefaultAsync<Patinet>(query, new { patinetId = patinetId });
         }

        public async Task<Patinet> AddPatinetAsync(Patinet patinet)
        {
            using var connection = _context.CreateConnection();
            var query = "INSERT INTO public.patient (patinetname , patinetage, dateofbirth) VALUES (@patinetName, @patinetAge, @dateOfBirth) RETURNING *";
            var insertedPatinet = await connection.QuerySingleAsync<Patinet>(query, patinet);
            
            return  insertedPatinet;
        }
    }
}
