using Apsoft.Domain.FinancialData;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database.Model;
using BancaSempione.Infrastructure.Repositories.Core;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class DivisaRepository(DivisaRecordRepository recordRepository) : DomainRepository<DivisaRecord, Divisa>(recordRepository),  IDivisaRepository
{
    public Dictionary<string, Divisa> DiviseByIsoCode => recordRepository.Items.AsEnumerable()
        .Select(ToDomain)
        .ToDictionary(x => x.AlphabeticCode, x => x);

    public Dictionary<string, Divisa> DiviseIn => recordRepository.Items.AsEnumerable()
        .Select(ToDomain)
        .Where(x => x.IsDivisaIn)
        .ToDictionary(x => x.AlphabeticCode, x => x);

    public Dictionary<int, Divisa> DiviseById => recordRepository.Items.AsEnumerable()
        .Select(ToDomain)
        .ToDictionary(x => x.DivisaId, x => x);

    public Divisa DivisaIstituto => recordRepository.Items.AsEnumerable()
        .Select(ToDomain)
        .Single(x => x.AlphabeticCode == Currency.CHF.AlphabeticCode);

    protected override Divisa ToDomain(DivisaRecord record)
    {
        return new Divisa(
            record.DivisaRecordId,
            record.AlphabeticCode,
            record.NumericCode,
            record.Name,
            record.Symbol,
            record.DecimalDigits,
            record.Rounding,
            record.IsDivisaIn,
            record.Taglio,
            record.GruppoDivisaId,
            record.TipoDivisaId
        );
    }

    protected override DivisaRecord FromDomain(Divisa divisa)
    {
        return new DivisaRecord
        {
            DivisaRecordId = divisa.DivisaId,
            AlphabeticCode = divisa.AlphabeticCode,
            NumericCode = divisa.NumericCode,
            Name = divisa.Name,
            Symbol = divisa.Symbol,
            DecimalDigits = divisa.DecimalDigits,
            Rounding = divisa.Rounding,
            IsDivisaIn = divisa.IsDivisaIn,
            Taglio = divisa.Taglio,
            GruppoDivisaId = divisa.GruppoDivisaId,
            TipoDivisaId = divisa.TipoDivisaId
        };
    }
}