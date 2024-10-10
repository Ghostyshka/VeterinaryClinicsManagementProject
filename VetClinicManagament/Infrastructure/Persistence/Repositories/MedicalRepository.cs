using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class MedicalRepository : IMedicalRepository
{
    private readonly DataContext _dataContext;

    public MedicalRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Medical>> GetAllAsync()
    {
        return await _dataContext.Medical.Include(m => m.MedicalsType).ToListAsync();
    }

    public async Task<Medical> GetByIdAsync(int id)
    {
        return await _dataContext.Medical.Include(m => m.MedicalsType)
            .FirstOrDefaultAsync(m => m.MedicalId == id);
    }

    public async Task AddAsync(Medical medical)
    {
        await _dataContext.Medical.AddAsync(medical);
        await _dataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Medical medical)
    {
        var existingMedical = await _dataContext.Medical.FindAsync(medical.MedicalId);
        if (existingMedical == null) return;

        existingMedical.MedicalName = medical.MedicalName;
        existingMedical.MedicalTypeId = medical.MedicalTypeId;
        existingMedical.Price = medical.Price;
        existingMedical.Quantity = medical.Quantity;

        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        int affectedRows = await _dataContext.Medical
            .Where(x => x.MedicalId == id)
            .ExecuteDeleteAsync();

        if (affectedRows == 0) return;
    }
}