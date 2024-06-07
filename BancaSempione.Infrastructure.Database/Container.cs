using BancaSempione.Infrastructure.Database.Logging;
using BancaSempione.Infrastructure.Logging.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Infrastructure.Database;

public static class Container
{
    public static IServiceCollection Register_BancaSempione_Infrastructure_Database(this IServiceCollection services, string connectionString)
    {
        Z.EntityFramework.Extensions.LicenseManager.AddLicense("6187;101-Apsoft", "c2221180-4596-29f3-c326-d0c443f379a0");
        
        services.WithSqlServer(connectionString);

        return services;
    }


    private static IServiceCollection WithSqlServer(this IServiceCollection services, string domainConnectionString)
    {
        services.AddDbContext<DivisaContext>(option => option
            .UseSqlServer(domainConnectionString,
                x =>
                {
                    x.MigrationsHistoryTable("__MigrationsHistory", "Divisa");
                }));
        return services;
    }

}