using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class MedicalTypeRepository : IMedicalTypeRepository
{
    private readonly DataContext _dataContext;

    public MedicalTypeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<MedicalType>> GetAllAsync()
    {
        return await _dataContext.MedicalType.ToListAsync();
    }

    public async Task<MedicalType> GetByIdAsync(int id)
    {
        return await _dataContext.MedicalType.FindAsync(id);
    }

    public async Task AddAsync(MedicalType medicalsType)
    {
        await _dataContext.MedicalType.AddAsync(medicalsType);
        await _dataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(MedicalType medicalsType)
    {
        var existingType = await _dataContext.MedicalType.FindAsync(medicalsType.TypeId);
        if (existingType == null) return;

        existingType.TypeName = medicalsType.TypeName;

        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        int affectedRows = await _dataContext.MedicalType
            .Where(x => x.TypeId == id)
            .ExecuteDeleteAsync();

        if (affectedRows == 0) return;
    }
}