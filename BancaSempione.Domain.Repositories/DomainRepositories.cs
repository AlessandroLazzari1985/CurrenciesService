using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories.Core;

namespace BancaSempione.Domain.Repositories;

public interface ICorsoDivisaRepository : IRepository<CorsoDivisa>
{
    List<CorsoDivisa> AsTemporal(long currentTimeUtc);
    long LastLoadUtc();
}

public interface IDivisaRepository : IRepository<Divisa>;
public interface IGruppoDivisaRepository : IRepository<GruppoDivisa>;
public interface ILogRepository : IRepository<SerilogRow>;
public interface ITipoDivisaRepository : IRepository<TipoDivisa>;