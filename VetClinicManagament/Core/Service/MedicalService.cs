using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Models.Dtos;

namespace Service;

public class MedicalService : IMedicalService
{
    private readonly IMedicalRepository _medicalsRepository;
    private readonly IMapper _mapper;


    public MedicalService(IMedicalRepository medicalsRepository, IMapper mapper)
    {
        _medicalsRepository = medicalsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicalDto>> GetAllAsync()
    {
        var medicals = await _medicalsRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MedicalDto>>(medicals);
    }

    public async Task<MedicalDto> GetByIdAsync(int id)
    {
        var medical = await _medicalsRepository.GetByIdAsync(id);
        return _mapper.Map<MedicalDto>(medical);
    }

    public async Task AddAsync(MedicalDto newMedical)
    {
        var medical = _mapper.Map<Medical>(newMedical);
        await _medicalsRepository.AddAsync(medical);
    }

    public async Task UpdateAsync(MedicalDto newMedical)
    {
        var medical = _mapper.Map<Medical>(newMedical);
        await _medicalsRepository.UpdateAsync(medical);
    }

    public async Task DeleteAsync(int id)
    {
        await _medicalsRepository.DeleteAsync(id);
    }
}