using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Application.Services
{
    public class PatientService : IPatinetRepository
    {
        private readonly IPatinetRepository _patinetRepository;
        
        public PatientService(IPatinetRepository patinetRepository)
        {
            _patinetRepository = patinetRepository;
        }
        
        public async Task AddPatinetAsync(Patinet patinet)
        {
            
        }
        
        public async Task GetPatinetByPatinetAsync(Patinet patinet)
        {
            
        }

    }
}