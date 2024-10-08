using Domain.Entities;
using Domain.Models.Dtos;
using AutoMapper;

namespace Domain.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Specie Mapping
        CreateMap<AddSpecieDto, Specie>()
            .ForMember(dest => dest.SpecieName, opt => opt.MapFrom(src => src.SpecieName))
            .ForMember(dest => dest.SpecieId, opt => opt.Ignore());

        //Breed Mapping
        CreateMap<AddBreedDto, Breed>()
            .ForMember(dest => dest.BreedName, opt => opt.MapFrom(src => src.BreedName))
            .ForMember(dest => dest.BreedId, opt => opt.Ignore());

        //Color Mapping
        CreateMap<AddColorDto, Color>()
            .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.ColorName))
            .ForMember(dest => dest.ColorId, opt => opt.Ignore());

        //Invoice Mapping
        CreateMap<Invoice, InvoiceDto>().ReverseMap();        
        
        //InvoiceItem Mapping
        CreateMap<InvoiceItem, InvoiceItemDto>().ReverseMap();

        //Visit Mapping
        CreateMap<Visit, VisitDto>().ReverseMap();

        //Service Mapping
        CreateMap<Service, ProcedureDto>().ReverseMap();

        //ServiceType Mapping
        CreateMap<ServiceType, ServiceTypeDto>().ReverseMap();
        CreateMap<ServiceType, ServiceTypeForProcedureDto>().ReverseMap();

        //TreatmentPlan Mapping
        CreateMap<TreatmentPlan, TreatmentPlanDto>().ReverseMap();
    }
}