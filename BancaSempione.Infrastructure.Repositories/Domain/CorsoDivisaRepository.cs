using AutoMapper;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Divise.Generic;
using BancaSempione.Domain.Repositories;
using BancaSempione.Domain.Services.Interfaces;
using BancaSempione.Infrastructure.Database.Model;
using BancaSempione.Infrastructure.Repositories.Core;
using BancaSempione.Infrastructure.Repositories.Records;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class CorsoDivisaRepository(CorsoDivisaRecordRepository recordRepository, IMapper mapper, IDivisaService divisaService) : 
    DomainRepository<CorsoDivisaRecord, CorsoDivisa>(recordRepository), ICorsoDivisaRepository
{
    protected override CorsoDivisa ToDomain(CorsoDivisaRecord record)
    {
        var baseCurrency = divisaService.DiviseById[record.BaseCurrencyCode];
        var counterCurrency = divisaService.DiviseById[record.CounterCurrencyCode];

        var currencyPair = new CoppiaDivise(baseCurrency, counterCurrency);
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
    }

    protected override CorsoDivisaRecord ToRecord(CorsoDivisa entity)
    {
        return mapper.Map<CorsoDivisaRecord>(entity);
    }

    public List<CorsoDivisa> AsTemporal(long currentTimeUtc)
    {
        return recordRepository.Items
            .Where(x => x.ValidFromUtc <= currentTimeUtc)
            .Where(x => x.ValidToUtc > currentTimeUtc)
            .AsEnumerable()
            .Select(ToDomain)
            .ToList();
    }

    public long LastLoadUtc()
    {
        if(recordRepository.Items.FirstOrDefault()== null)
            return 0;

        return recordRepository.Items.Max(x => x.ValidFromUtc);
    }

}
