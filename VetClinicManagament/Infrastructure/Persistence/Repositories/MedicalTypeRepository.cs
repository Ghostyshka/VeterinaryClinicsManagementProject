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

    public async Task<IEnumerable<MedicalsTypes>> GetAllAsync()
    {
        return await _dataContext.MedicalType.ToListAsync();
    }

    public async Task<MedicalsTypes> GetByIdAsync(int id)
    {
        return await _dataContext.MedicalType.FindAsync(id);
    }

    public async Task AddAsync(MedicalsTypes medicalsType)
    {
        await _dataContext.MedicalType.AddAsync(medicalsType);
        await _dataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(MedicalsTypes medicalsType)
    {
        var existingType = await _dataContext.MedicalType.FindAsync(medicalsType.TypeId);
        if (existingType == null) return;

        existingType.TypeName = medicalsType.TypeName;

        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var medicalsType = await _dataContext.MedicalType.FindAsync(id);
        if (medicalsType != null)
        {
            _dataContext.MedicalType.Remove(medicalsType);
            await _dataContext.SaveChangesAsync();
        }
    }
}