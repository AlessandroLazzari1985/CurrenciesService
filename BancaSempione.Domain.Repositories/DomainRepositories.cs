using Apsoft.Domain.FinancialData;
using Apsoft.Domain.Repositories.Core;
using BancaSempione.Domain.Divise;

namespace BancaSempione.Domain.Repositories;

public interface ICorsoDivisaRepository : IRepository<CorsoDivisa>;
public interface ICurrencyPairRepository : IRepository<CurrencyPair>;
public interface IDivisaRepository : IRepository<Divisa>;
public interface IGruppoDivisaRepository : IRepository<GruppoDivisa>;
public interface ILogRepository : IRepository<SerilogRow>;
public interface ITipoDivisaRepository : IRepository<TipoDivisa>;