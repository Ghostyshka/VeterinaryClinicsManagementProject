using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Models.Dtos;

namespace Service;

public class MedicalTypeService : IMedicalTypeService
{
    private readonly IMedicalTypeRepository _repository;
    private readonly IMapper _mapper;

    public MedicalTypeService(IMedicalTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicalTypeDto>> GetAllMedicalTypesAsync()
    {
        var medicalTypes = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<MedicalTypeDto>>(medicalTypes);
    }

    public async Task<MedicalTypeDto> GetMedicalTypeByIdAsync(int id)
    {
        var medicalType = await _repository.GetByIdAsync(id);
        return _mapper.Map<MedicalTypeDto>(medicalType);
    }

    public async Task AddMedicalTypeAsync(MedicalTypeDto medicalTypeDto)
    {
        var medicalType = _mapper.Map<MedicalType>(medicalTypeDto);
        await _repository.AddAsync(medicalType);
    }

    public async Task UpdateMedicalTypeAsync(int id, MedicalTypeDto medicalTypeDto)
    {
        var medicalType = await _repository.GetByIdAsync(id);
        if (medicalType != null)
        {
            _mapper.Map(medicalTypeDto, medicalType);
            await _repository.UpdateAsync(medicalType);
        }
    }

    public async Task DeleteMedicalTypeAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}