using BancaSempione.Infrastructure.Database.Model;
using BancaSempione.Infrastructure.Repositories.Core;
using Microsoft.EntityFrameworkCore;

namespace BancaSempione.Infrastructure.Repositories;

public class DivisaRecordRepository(DbContext context) : Repository<DivisaRecord>(context) { }