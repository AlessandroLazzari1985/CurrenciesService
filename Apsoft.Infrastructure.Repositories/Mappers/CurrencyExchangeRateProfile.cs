using Apsoft.Domain.FinancialData;
using Apsoft.Infrastructure.Database.Model;
using AutoMapper;

namespace Apsoft.Infrastructure.Repositories.Mappers;

public class CurrencyExchangeRateProfile : Profile
{
    public CurrencyExchangeRateProfile()
    {
        CreateMap<CurrencyExchangeRate, ActualCurrencyExchangeRate>()
            .ForMember(dest => dest.BaseCurrencyCode, opt => opt.MapFrom(src => src.CurrencyPair.BaseCurrency.AlphabeticCode))
            .ForMember(dest => dest.CounterCurrencyCode, opt => opt.MapFrom(src => src.CurrencyPair.CounterCurrency.AlphabeticCode));

        CreateMap<ActualCurrencyExchangeRate, CurrencyExchangeRate>()
            .ConstructUsing((record, context) =>
            {
                var baseCurrency = Currency.GetByNumericCode(record.BaseCurrencyCode);
                var counterCurrency = Currency.GetByNumericCode(record.CounterCurrencyCode);

                var currencyPair = new CurrencyPair(baseCurrency, counterCurrency);
                var validPeriod = new Period(record.ValidFromUtc, record.ValidToUtc);

                return new CurrencyExchangeRate(
                    currencyPair,
                    record.BidRate,
                    record.AskRate,
                    validPeriod,
                    record.PreviousExchangeRate);
            });
    }
}
