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
            .ForMember(dest => dest.BaseCurrencyCode, opt => opt.MapFrom(src => src.CurrencyExchangeRate.CurrencyPair.BaseCurrency.AlphabeticCode))
            .ForMember(dest => dest.CounterCurrencyCode, opt => opt.MapFrom(src => src.CurrencyExchangeRate.CurrencyPair.CounterCurrency.AlphabeticCode));

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

                return new CorsoDivisa(currencyExchangeRate, record.TipoCorsoDivisa);
            });
    }
}