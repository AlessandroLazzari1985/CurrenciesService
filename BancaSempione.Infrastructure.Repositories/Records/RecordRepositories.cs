using Apsoft.Infrastructure.Repositories.Core;
using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Database.Model;

namespace BancaSempione.Infrastructure.Repositories.Records;


public class DivisaRecordRepository(DivisaContext context) : Repository<DivisaRecord>(context);
public class CorsoDivisaRecordRepository(DivisaContext context) : Repository<CorsoDivisaRecord>(context);
