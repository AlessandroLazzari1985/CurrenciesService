using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Database.Model;
using BancaSempione.Infrastructure.Repositories.Core;

namespace BancaSempione.Infrastructure.Repositories.Records;


public class DivisaRecordRepository(DivisaContext context) : Repository<DivisaRecord>(context);
public class CorsoDivisaRecordRepository(DivisaContext context) : Repository<CorsoDivisaRecord>(context);
