using AutoMapper;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database.Model;
using BancaSempione.Infrastructure.Repositories.Core;
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
