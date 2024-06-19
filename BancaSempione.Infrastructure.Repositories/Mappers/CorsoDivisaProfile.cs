using AutoMapper;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Divise.Generic;
using BancaSempione.Infrastructure.Database.Model;

namespace BancaSempione.Infrastructure.Repositories.Mappers;

public class CorsoDivisaProfile : Profile
{
    public CorsoDivisaProfile()
    {
        CreateMap<CorsoDivisa, CorsoDivisaRecord>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BaseCurrencyCode, opt => opt.MapFrom(src => src.CoppiaDivise.DivisaBase.NumericCode))
            .ForMember(dest => dest.CounterCurrencyCode, opt => opt.MapFrom(src => src.CoppiaDivise.DivisaContro.NumericCode))
            //.ForMember(dest => dest.BidRate, opt => opt.MapFrom(src => src.BidRate))
            //.ForMember(dest => dest.AskRate, opt => opt.MapFrom(src => src.AskRate))
            //.ForMember(dest => dest.PreviousExchangeRate, opt => opt.MapFrom(src => src.PreviousExchangeRate))
            .ForMember(dest => dest.ValidFromUtc, opt => opt.MapFrom(src => src.ValidPeriod.StartUtc))
            .ForMember(dest => dest.ValidToUtc, opt => opt.MapFrom(src => src.ValidPeriod.EndUtc))
            // .ForMember(dest => dest.TipoCorsoDivisa, opt => opt.MapFrom(src => src.TipoCorsoDivisa))
            ;

        CreateMap<CorsoDivisaRecord, CorsoDivisa>()
            .ConstructUsing((record, context) =>
            {
                // TODO Risolvere qui il problema delle divise
                //var baseCurrency = Currency.GetByNumericCode(record.BaseCurrencyCode);
                //var counterCurrency = Currency.GetByNumericCode(record.CounterCurrencyCode);

                var currencyPair = new CoppiaDivise(null, null);
                var validPeriod = new Period(record.ValidFromUtc, record.ValidToUtc);

                var currencyExchangeRate = new CorsoDivisa(
                    currencyPair,
                    record.BidRate,
                    record.AskRate,
                    validPeriod,
                    record.PreviousExchangeRate,
                    record.TipoCorsoDivisa);

                // TODO. CHeidere a Daniele se questo è corretto!! Anche la set su id
                currencyExchangeRate.Id = record.Id;

                return currencyExchangeRate;
            });
    }
}