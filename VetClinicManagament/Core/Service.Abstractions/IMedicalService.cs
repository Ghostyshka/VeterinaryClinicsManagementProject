using Domain.Models.Dtos;

namespace Contracts;

public interface IMedicalService
{
    Task<IEnumerable<MedicalDto>> GetAllAsync();
    Task<MedicalDto> GetByIdAsync(int id);
    Task AddAsync(MedicalDto medical);
    Task UpdateAsync(MedicalDto medical);
    Task DeleteAsync(int id);
}