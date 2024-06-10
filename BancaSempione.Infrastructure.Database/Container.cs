using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Infrastructure.Database;

public static class Container
{
    public static IServiceCollection Register_BancaSempione_Infrastructure_Database(this IServiceCollection services, 
        string defaultConnectionString,
        string bossConnectionString)
    {
        Z.EntityFramework.Extensions.LicenseManager.AddLicense("6187;101-Apsoft", "c2221180-4596-29f3-c326-d0c443f379a0");
        
        services.RegisterDivisaContext(defaultConnectionString);
        services.RegisterBossContext(bossConnectionString);

        return services;
    }
    
    private static IServiceCollection RegisterDivisaContext(this IServiceCollection services, string domainConnectionString)
    {
        return services.AddDbContext<DivisaContext>(option => option
            .UseSqlServer(domainConnectionString, x => { x.MigrationsHistoryTable("__MigrationsHistory", PublicNames.DefaltSchema); }));
    }

    private static IServiceCollection RegisterBossContext(this IServiceCollection services, string domainConnectionString)
    {
        return services.AddDbContext<BossContext>(option => option.UseSqlServer(domainConnectionString));
    }
}