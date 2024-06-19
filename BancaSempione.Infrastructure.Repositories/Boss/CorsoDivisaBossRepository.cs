using BancaSempione.Domain.Boss;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Repositories.Core;

namespace BancaSempione.Infrastructure.Repositories.Boss;

public class CorsoDivisaBossRepository(BossContext context) : Repository<CorsoDivisaBoss>(context), ICorsoDivisaBossRepository;
