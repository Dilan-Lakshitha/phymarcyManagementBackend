using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Application.Services
{
    public class DrugService : IDrugService
    {
        private readonly IDrugRepository _drugRepository;

        public DrugService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        public Task<IEnumerable<Drug>> GetAllDrugsAsync() => _drugRepository.GetAllDrugsAsync();
        public Task<Drug> GetDrugByIdAsync(int id) => _drugRepository.GetDrugByIdAsync(id);
        public Task<Drug> AddDrugAsync(Drug drug) => _drugRepository.AddDrugAsync(drug);
        public Task<Drug> UpdateDrugAsync(Drug drug) => _drugRepository.UpdateDrugAsync(drug);
        public Task DeleteDrugAsync(int id) => _drugRepository.DeleteDrugAsync(id);
    }   
}