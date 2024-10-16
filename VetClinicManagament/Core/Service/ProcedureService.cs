using Contracts;
using Domain.Repositories;
using ServiceModel = Domain.Entities.Service;

namespace Service;

public class ProcedureService : IProcedureService
{
    private readonly IServiceRepository _serviceRepository;

    public ProcedureService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<IEnumerable<ServiceModel>> GetAllAsync()
    {
        return await _serviceRepository.GetAllAsync();
    }

    public async Task<ServiceModel> GetByIdAsync(int id)
    {
        return await _serviceRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(ServiceModel service)
    {
        await _serviceRepository.AddAsync(service);
    }

    public async Task UpdateAsync(ServiceModel service)
    {
        await _serviceRepository.UpdateAsync(service);
    }

    public async Task DeleteAsync(int id)
    {
        await _serviceRepository.DeleteAsync(id);
    }
}