using Apsoft.Infrastructure.Repositories.Core;
using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Database.Model;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class DivisaRecordRepository(DivisaContext context) : Repository<DivisaRecord>(context);