using AutoMapper;
using Domain.Repositories;
using Domain.Models.Dtos;
using Domain.Entities;
using Contracts;
using Persistence.Repositories;

namespace Service;

public class VisitService : IVisitService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public VisitService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VisitDto>> GetAllAsync()
    {
        var visits = await _repositoryManager.VisitRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<VisitDto>>(visits);
    }

    public async Task<VisitDto> GetByIdAsync(int id)
    {
        var visit = await _repositoryManager.VisitRepository.GetByIdAsync(id);
        return _mapper.Map<VisitDto>(visit);
    }

    public async Task<VisitDto> AddAsync(VisitDto visitDto)
    {
        var visit = _mapper.Map<Visit>(visitDto);
        await _repositoryManager.VisitRepository.AddAsync(visit);
        return _mapper.Map<VisitDto>(visit);
    }

    public async Task<VisitDto> UpdateAsync(VisitDto visitDto)
    {
        var visit = _mapper.Map<Visit>(visitDto);
        await _repositoryManager.VisitRepository.UpdateAsync(visit);
        return _mapper.Map<VisitDto>(visit);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repositoryManager.VisitRepository.DeleteAsync(id);
    }
}