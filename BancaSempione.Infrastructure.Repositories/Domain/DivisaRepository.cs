using AutoMapper;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database.Model;
using BancaSempione.Infrastructure.Repositories.Core;
using BancaSempione.Infrastructure.Repositories.Records;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class DivisaRepository(DivisaRecordRepository recordRepository, IMapper mapper) : DomainRepository<DivisaRecord, Divisa>(recordRepository), IDivisaRepository
{
    protected override Divisa ToDomain(DivisaRecord record)
    {
        return mapper.Map<Divisa>(record);
    }

    protected override DivisaRecord ToRecord(Divisa entity)
    {
        return mapper.Map<DivisaRecord>(entity);
    }
}