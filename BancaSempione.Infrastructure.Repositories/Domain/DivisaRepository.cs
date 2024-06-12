using Apsoft.Infrastructure.Repositories.Core;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database.Model;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class DivisaRepository(DivisaRecordRepository recordRepository) : DomainRepository<DivisaRecord, Divisa>(recordRepository), IDivisaRepository
{
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

    protected override DivisaRecord ToRecord(Divisa divisa)
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