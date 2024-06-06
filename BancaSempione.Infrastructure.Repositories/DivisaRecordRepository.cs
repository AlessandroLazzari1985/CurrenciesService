using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Database.Model;
using BancaSempione.Infrastructure.Repositories.Core;

namespace BancaSempione.Infrastructure.Repositories;

public class DivisaRecordRepository(DivisaContext context) : Repository<DivisaRecord>(context) { }