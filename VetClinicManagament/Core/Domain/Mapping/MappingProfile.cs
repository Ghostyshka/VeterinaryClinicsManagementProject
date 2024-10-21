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
        CreateMap<Invoice, InvoiceDto>()
            .ForMember(dest => dest.InvoiceItems, opt => opt.MapFrom(
                src => src.InvoiceItems.Select(item => item.ItemId).ToList()));

        //InvoiceItem Mapping
        CreateMap<InvoiceItem, InvoiceItemDto>().ReverseMap();

        //InvoiceItemDto Mapping
        CreateMap<InvoiceDto, Invoice>()
            .ForMember(dest => dest.InvoiceItems, opt => opt.Ignore())
            .ReverseMap();

        //Visit Mapping
        CreateMap<Visit, VisitDto>().ReverseMap();

        //Service Mapping
        CreateMap<ProcedureDto, Service>()
        .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.ServiceId))
        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ServicePrice))
        .ForMember(dest => dest.MedicalId, opt => opt.MapFrom(src => src.MedicalId))
        .ForMember(dest => dest.ServiceTypeId, opt => opt.MapFrom(src => src.ServiceTypeId));

        //ServiceType Mapping
        CreateMap<ServiceType, ServiceTypeDto>().ReverseMap();

        //TreatmentPlan Mapping
        CreateMap<TreatmentPlan, TreatmentPlanDto>().ReverseMap();

        // TreatmentPlanItem Mapping
        CreateMap<TreatmentPlanItem, TreatmentPlanItemDto>().ReverseMap();

        // Medicals Mapping
        CreateMap<Medical, MedicalDto>().ReverseMap();

        // MedicalType Mapping
        CreateMap<MedicalType, MedicalTypeDto>().ReverseMap();

        // Invoice -> InvoiceVisitDetailsDto Mapping
        CreateMap<Invoice, InvoiceVisitDetailsDto>()
            .ForMember(dest => dest.VisitId, opt => opt.MapFrom(src => src.VisitId))
            .ForMember(dest => dest.VisitDate, opt => opt.MapFrom(src => src.Visit.DataOfVisit))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Visit.User.FullName))
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Visit.Employee.EmployeeFullName))
            .ForMember(dest => dest.InvoiceItems, opt => opt.MapFrom(src => src.InvoiceItems.Select(item => new InvoiceItemDto
            {
                ItemType = item.ItemType
            }).ToList()));
    }
}