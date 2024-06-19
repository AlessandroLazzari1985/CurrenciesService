using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;

namespace BancaSempione.Domain.Services.Managers;

public interface ICorsoDivisaService
{
    List<CorsoDivisa> CorsiDivisa { get; }
    List<CorsoDivisa> GetCorsiDivisaAt(DateTime dateTime);
}

public class CorsoDivisaService(ICorsoDivisaRepository repository) : ICorsoDivisaService
{
    public List<CorsoDivisa> CorsiDivisa => repository
        .AsTemporal(DateTime.Now.ToFileTimeUtc())
        .ToList();

    public List<CorsoDivisa> GetCorsiDivisaAt(DateTime dateTime) => repository
        .AsTemporal(dateTime.ToFileTimeUtc())
        .ToList();

}