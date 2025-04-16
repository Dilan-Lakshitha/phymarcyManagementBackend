using phymarcyManagement.Domain.Entities;

namespace phymarcyManagement.Application.Interfaces;

public interface IDrugRepository
{
    Task<IEnumerable<Drug>> GetAllDrugsAsync();
    Task<Drug> GetDrugByIdAsync(int id);
    Task<Drug> AddDrugAsync(Drug drug);
    Task<Drug> UpdateDrugAsync(Drug drug);
    Task DeleteDrugAsync(int id);
}