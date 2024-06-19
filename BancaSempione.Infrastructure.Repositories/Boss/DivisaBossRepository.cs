using BancaSempione.Domain.Boss;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Repositories.Core;

namespace BancaSempione.Infrastructure.Repositories.Boss;

internal class DivisaBossRepository(BossContext context) : Repository<DivisaBoss>(context), IDivisaBossRepository;
