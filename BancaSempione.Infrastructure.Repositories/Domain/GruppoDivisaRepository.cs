using Apsoft.Infrastructure.Repositories.Core;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class GruppoDivisaRepository(DivisaContext context): Repository<GruppoDivisa>(context), IGruppoDivisaRepository;
