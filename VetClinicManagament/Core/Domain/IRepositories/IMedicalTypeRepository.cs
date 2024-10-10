using Domain.Entities;

namespace Domain.IRepositories;

public interface IMedicalTypeRepository
{
    Task<IEnumerable<MedicalType>> GetAllAsync();
    Task<MedicalType> GetByIdAsync(int id);
    Task AddAsync(MedicalType medicalType);
    Task UpdateAsync(MedicalType medicalType);
    Task DeleteAsync(int id);
}