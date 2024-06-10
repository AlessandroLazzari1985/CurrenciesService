using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Database.Model;
using BancaSempione.Infrastructure.Repositories.Core;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class DivisaRecordRepository(DivisaContext context) : Repository<DivisaRecord>(context) { }