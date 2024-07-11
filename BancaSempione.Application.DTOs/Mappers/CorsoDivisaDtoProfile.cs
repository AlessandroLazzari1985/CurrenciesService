using AutoMapper;
using BancaSempione.Application.DTOs.Dtos;
using BancaSempione.Domain.Divise;

namespace BancaSempione.Application.DTOs.Mappers;

public class CorsoDivisaDtoProfile : Profile
{
    public CorsoDivisaDtoProfile()
    {
        CreateMap<CorsoDivisa, CorsoDivisaDto>()
            .ForMember(dest => dest.CorsoDivisaId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BaseCurrencyCode, opt => opt.MapFrom(src => src.CoppiaDivise.DivisaBase.AlphabeticCode))
            .ForMember(dest => dest.CounterCurrencyCode, opt => opt.MapFrom(src => src.CoppiaDivise.DivisaContro.AlphabeticCode))
            .ForMember(dest => dest.BaseCurrency, opt => opt.MapFrom(src => src.CoppiaDivise.DivisaBase))
            .ForMember(dest => dest.CounterCurrency, opt => opt.MapFrom(src => src.CoppiaDivise.DivisaContro))
            .ForMember(dest => dest.BidRate, opt => opt.MapFrom(src => src.BidRate))
            .ForMember(dest => dest.AskRate, opt => opt.MapFrom(src => src.AskRate))
            .ForMember(dest => dest.ExchangeRate, opt => opt.MapFrom(src => src.ExchangeRate))
            .ForMember(dest => dest.PreviousExchangeRate, opt => opt.MapFrom(src => src.PreviousExchangeRate))
            .ForMember(dest => dest.Performance, opt => opt.MapFrom(src => src.Performance))
            .ForMember(dest => dest.Spread, opt => opt.MapFrom(src => src.Spread))
            .ForMember(dest => dest.ValidFrom, opt => opt.MapFrom(src => src.ValidPeriod.Start))
            .ForMember(dest => dest.ValidTo, opt => opt.MapFrom(src => src.ValidPeriod.End));
    }
}