using Domain.Models.Dtos;

namespace Contracts;

public interface IVisitService
{
    Task<IEnumerable<VisitDto>> GetAllAsync();
    Task<VisitDto> GetByIdAsync(int id);
    Task<VisitDto> AddAsync(VisitDto visitDto);
    Task<VisitDto> UpdateAsync(VisitDto visitDto);
    Task<bool> DeleteAsync(int id);
}