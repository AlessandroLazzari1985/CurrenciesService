using Apsoft.Domain.FinancialData;
using Apsoft.Infrastructure.Repositories.Core;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database.Model;

namespace BancaSempione.Infrastructure.Repositories.Domain;


public class CurrencyPairRecordRepository(Repository<CurrencyPairRecord> recordRepository) : DomainRepository<CurrencyPairRecord, CurrencyPair>(recordRepository), ICurrencyPairRepository
{
    private static readonly List<Currency> Currencis = Currency.GetAll();
    private readonly Repository<CurrencyPairRecord> _recordRepository = recordRepository;

    protected override CurrencyPair ToDomain(CurrencyPairRecord record)
    {
        var baseCurrency = Currencis.Single(x => x.NumericCode == record.BaseCurrencyId);
        var counterCurrency = Currencis.Single(x => x.NumericCode == record.CounterCurrencyId);

        return new CurrencyPair(baseCurrency, counterCurrency);
    }

    protected override CurrencyPairRecord ToRecord(CurrencyPair entity)
    {
        var result = _recordRepository.Items
            .SingleOrDefault(x => x.BaseCurrencyId == entity.BaseCurrency.NumericCode &&
                                  x.CounterCurrencyId == entity.CounterCurrency.NumericCode) ?? new CurrencyPairRecord
        {
            CurrencyPairRecordId = Guid.NewGuid(),
            BaseCurrencyId = entity.BaseCurrency.NumericCode,
            CounterCurrencyId = entity.CounterCurrency.NumericCode
        };


        return result;
    }
}
