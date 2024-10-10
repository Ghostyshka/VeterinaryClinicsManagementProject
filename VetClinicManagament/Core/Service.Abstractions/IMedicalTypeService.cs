using Domain.Models.Dtos;

namespace Contracts;

public interface IMedicalTypeService
{
    Task<IEnumerable<MedicalTypeDto>> GetAllMedicalTypesAsync();
    Task<MedicalTypeDto> GetMedicalTypeByIdAsync(int id);
    Task AddMedicalTypeAsync(MedicalTypeDto medicalTypeDto);
    Task UpdateMedicalTypeAsync(int id, MedicalTypeDto medicalTypeDto);
    Task DeleteMedicalTypeAsync(int id);
}