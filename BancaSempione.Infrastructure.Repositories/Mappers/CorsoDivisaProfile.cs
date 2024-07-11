using AutoMapper;
using BancaSempione.Domain.Divise;
using BancaSempione.Infrastructure.Database.Model;

namespace BancaSempione.Infrastructure.Repositories.Mappers;

public class CorsoDivisaProfile : Profile
{
    public CorsoDivisaProfile()
    {
        CreateMap<CorsoDivisa, CorsoDivisaRecord>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BaseCurrencyCode, opt => opt.MapFrom(src => src.CoppiaDivise.DivisaBase.DivisaId))
            .ForMember(dest => dest.CounterCurrencyCode, opt => opt.MapFrom(src => src.CoppiaDivise.DivisaContro.DivisaId))
            .ForMember(dest => dest.ValidFromUtc, opt => opt.MapFrom(src => src.ValidPeriod.StartUtc))
            .ForMember(dest => dest.ValidToUtc, opt => opt.MapFrom(src => src.ValidPeriod.EndUtc))
            ;
    }
}