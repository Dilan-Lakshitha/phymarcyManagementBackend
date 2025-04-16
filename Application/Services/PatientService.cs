using Microsoft.VisualBasic;
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
                customer_name = patinetRequest.customer_name,
                customer_age = patinetRequest.customer_age,
                customer_contact = patinetRequest.customer_contact,
            };
            
            var addPatinet = await _patinetRepository.AddPatinetAsync(patinet);
            
            if (addPatinet == null)
            {
                return null;
            }


            var getPatinetDetails = await _patinetRepository.GetPatinetByPatinetAsync(addPatinet.customer_id);
            
            return getPatinetDetails; 
        }

        public async Task<List<Patinet>> GetPatinetsDataAsync()
        {
            var patientList = await _patinetRepository.GetPatinetsAsync();
            
            return patientList;
        }
        
        public async Task<Patinet?> UpdatePatientAsync(int id, PatinetRegister patinetRequest)
        {
            var existingPatient = await _patinetRepository.GetPatinetByPatinetAsync(id);
            if (existingPatient == null) return null;

            existingPatient.customer_name = patinetRequest.customer_name;
            existingPatient.customer_age = patinetRequest.customer_age;
            existingPatient.customer_contact = patinetRequest.customer_contact;

            return await _patinetRepository.UpdatePatinetAsync(existingPatient);
        }

        public async Task<int?> DeletePatientAsync(int id)
        {
            var existing = await _patinetRepository.GetPatinetByPatinetAsync(id);
            if (existing == null) return null;

            var isDeleted = await _patinetRepository.DeletePatinetAsync(id);
            return isDeleted ? id : null;
        }
    }
}