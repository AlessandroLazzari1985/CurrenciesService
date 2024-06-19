using Apsoft.Domain.FinancialData;
using AutoMapper;
using BancaSempione.Domain.Divise;
using BancaSempione.Infrastructure.Database.Model;

namespace BancaSempione.Infrastructure.Repositories.Mappers;

public class CorsoDivisaProfile : Profile
{
    public CorsoDivisaProfile()
    {
        CreateMap<CorsoDivisa, CorsoDivisaRecord>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CurrencyExchangeRate.Id))
            .ForMember(dest => dest.BaseCurrencyCode, opt => opt.MapFrom(src => src.CurrencyExchangeRate.CurrencyPair.BaseCurrency.NumericCode))
            .ForMember(dest => dest.CounterCurrencyCode, opt => opt.MapFrom(src => src.CurrencyExchangeRate.CurrencyPair.CounterCurrency.NumericCode))
            .ForMember(dest => dest.BidRate, opt => opt.MapFrom(src => src.CurrencyExchangeRate.BidRate))
            .ForMember(dest => dest.AskRate, opt => opt.MapFrom(src => src.CurrencyExchangeRate.AskRate))
            .ForMember(dest => dest.PreviousExchangeRate, opt => opt.MapFrom(src => src.CurrencyExchangeRate.PreviousExchangeRate))
            .ForMember(dest => dest.ValidFromUtc, opt => opt.MapFrom(src => src.CurrencyExchangeRate.ValidPeriod.StartUtc))
            .ForMember(dest => dest.ValidToUtc, opt => opt.MapFrom(src => src.CurrencyExchangeRate.ValidPeriod.EndUtc))
            .ForMember(dest => dest.TipoCorsoDivisa, opt => opt.MapFrom(src => src.TipoCorsoDivisa))
            ;

        CreateMap<CorsoDivisaRecord, CorsoDivisa>()
            .ConstructUsing((record, context) =>
            {
                var baseCurrency = Currency.GetByNumericCode(record.BaseCurrencyCode);
                var counterCurrency = Currency.GetByNumericCode(record.CounterCurrencyCode);

                var currencyPair = new CurrencyPair(baseCurrency, counterCurrency);
                var validPeriod = new Period(record.ValidFromUtc, record.ValidToUtc);

                var currencyExchangeRate = new CurrencyExchangeRate(
                    currencyPair,
                    record.BidRate,
                    record.AskRate,
                    validPeriod,
                    record.PreviousExchangeRate);

                // TODO. CHeidere a Daniele se questo è corretto!! Anche la set su id
                currencyExchangeRate.Id = record.Id;

                return new CorsoDivisa(currencyExchangeRate, record.TipoCorsoDivisa);
            });
    }
}