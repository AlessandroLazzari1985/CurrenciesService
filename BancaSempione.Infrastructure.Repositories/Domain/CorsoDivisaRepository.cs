using Apsoft.Infrastructure.Repositories.Core;
using AutoMapper;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database.Model;
using BancaSempione.Infrastructure.Repositories.Records;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class CorsoDivisaRepository(CorsoDivisaRecordRepository recordRepository, IMapper mapper) : 
    DomainRepository<CorsoDivisaRecord, CorsoDivisa>(recordRepository), ICorsoDivisaRepository
{
    protected override CorsoDivisa ToDomain(CorsoDivisaRecord record)
    {
        return mapper.Map<CorsoDivisa>(record);
    }

    protected override CorsoDivisaRecord ToRecord(CorsoDivisa entity)
    {
        return mapper.Map<CorsoDivisaRecord>(entity);
    }
}
