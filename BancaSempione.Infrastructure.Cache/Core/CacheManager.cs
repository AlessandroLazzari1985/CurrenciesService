using Microsoft.Extensions.Caching.Memory;

namespace BancaSempione.Infrastructure.Cache.Core;

public class CacheManager(IMemoryCache cache)
{
    private static readonly object Lock = new();

    public T GetFromCache<T>(string cacheKey, Func<T> func)
    {
        lock (Lock)
        {
            return cache.GetOrCreate(cacheKey, x =>
            {
                x.SetAbsoluteExpiration(TimeSpan.FromMinutes(180));
                return func();
            }) ?? throw new InvalidOperationException($"Missing {cacheKey}");
        }
    }
}