using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;
using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Application.Services
{
    public class PatientService : IPatinetService
    {
        private readonly IPatinetRepository _patinetRepository;
        
        public PatientService(IPatinetRepository patinetRepository)
        {
            _patinetRepository = patinetRepository;
        }
        
        public async Task<Patinet?> AddPatinetDataAsync(PatinetRegister patinetRequest)
        {
            var patinet = new Patinet
            {
                patinetName = patinetRequest.PatinetName,
                patinetAge = patinetRequest.PatinetAge,
                dateOfBirth = patinetRequest.DateOfBirth,
            };
            
            var addPatinet = await _patinetRepository.AddPatinetAsync(patinet);
            
            if (addPatinet == null)
            {
                return null;
            }


            var getPatinetDetails = await _patinetRepository.GetPatinetByPatinetAsync(addPatinet.patinetId);
            
            return getPatinetDetails; 
        }
        
    }
}