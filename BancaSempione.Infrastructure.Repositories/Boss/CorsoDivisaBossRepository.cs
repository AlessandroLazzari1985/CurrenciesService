using BancaSempione.Domain.Boss;
using BancaSempione.Domain.Repositories.Boss;
using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Repositories.Core;

namespace BancaSempione.Infrastructure.Repositories.Boss;

internal class CorsoDivisaBossRepository(BossContext context) : Repository<CorsoDivisaBoss>(context), ICorsoDivisaBossRepository { }