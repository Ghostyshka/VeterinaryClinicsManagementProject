using Contracts;
using Domain.Entities;
using Domain.Repositories;

namespace Service;

public class ServiceTypeService : IServiceTypeService
{
    private readonly IServiceTypeRepository _serviceTypeRepository;

    public ServiceTypeService(IServiceTypeRepository serviceTypeRepository)
    {
        _serviceTypeRepository = serviceTypeRepository;
    }

    public async Task<IEnumerable<ServiceType>> GetAllAsync()
    {
        return await _serviceTypeRepository.GetAllAsync();
    }

    public async Task<ServiceType> GetByIdAsync(int id)
    {
        return await _serviceTypeRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(ServiceType serviceType)
    {
        await _serviceTypeRepository.AddAsync(serviceType);
    }

    public async Task UpdateAsync(ServiceType serviceType)
    {
        await _serviceTypeRepository.UpdateAsync(serviceType);
    }

    public async Task DeleteAsync(int id)
    {
        await _serviceTypeRepository.DeleteAsync(id);
    }
}