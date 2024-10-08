using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Models.Dtos;
using Domain.Repositories;

namespace Service;

public class TreatmentPlanService : ITreatmentPlanService
{
    private readonly ITreatmentPlanRepository _treatmentPlanRepository;
    private readonly IMapper _mapper;

    public TreatmentPlanService(ITreatmentPlanRepository treatmentPlanRepository, IMapper mapper)
    {
        _treatmentPlanRepository = treatmentPlanRepository;
        _mapper = mapper;
    }

    public async Task<TreatmentPlanDto> GetByIdAsync(int id)
    {
        var treatmentPlan = await _treatmentPlanRepository.GetByIdAsync(id);
        return _mapper.Map<TreatmentPlanDto>(treatmentPlan);
    }

    public async Task<IEnumerable<TreatmentPlanDto>> GetAllAsync()
    {
        var treatmentPlans = await _treatmentPlanRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<TreatmentPlanDto>>(treatmentPlans);
    }

    public async Task<TreatmentPlanDto> AddAsync(TreatmentPlanDto treatmentPlanDto)
    {
        var treatmentPlan = _mapper.Map<TreatmentPlan>(treatmentPlanDto);
        await _treatmentPlanRepository.AddAsync(treatmentPlan);
        return _mapper.Map<TreatmentPlanDto>(treatmentPlan);
    }

    public async Task<TreatmentPlanDto> UpdateAsync(TreatmentPlanDto treatmentPlanDto)
    {
        var treatmentPlan = _mapper.Map<TreatmentPlan>(treatmentPlanDto);
        await _treatmentPlanRepository.UpdateAsync(treatmentPlan);
        return _mapper.Map<TreatmentPlanDto>(treatmentPlan);
    }

    public async Task DeleteAsync(int id)
    {
        await _treatmentPlanRepository.DeleteAsync(id);
    }
}