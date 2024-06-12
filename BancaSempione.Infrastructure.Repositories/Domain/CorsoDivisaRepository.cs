using Apsoft.Infrastructure.Repositories.Core;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database.Model;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class CorsoDivisaRepository(Repository<CorsoDivisaRecord> recordRepository) : 
    DomainRepository<CorsoDivisaRecord, CorsoDivisa>(recordRepository), ICorsoDivisaRepository
{
    protected override CorsoDivisa ToDomain(CorsoDivisaRecord record)
    {
        throw new NotImplementedException();
    }

    protected override CorsoDivisaRecord ToRecord(CorsoDivisa entity)
    {
        throw new NotImplementedException();
    }
}
