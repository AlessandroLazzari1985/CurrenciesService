using Apsoft.Infrastructure.Repositories.Core;
using BancaSempione.Domain.Boss;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database;

namespace BancaSempione.Infrastructure.Repositories.Boss;

internal class CorsoDivisaBossRepository(BossContext context) : Repository<CorsoDivisaBoss>(context), ICorsoDivisaBossRepository;
