using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Apsoft.Infrastructure.Database;

public static class Container
{
    public static IServiceCollection Register_Apsoft_Infrastructure_Database(this IServiceCollection services, string defaultConnectionString)
    {
        Z.EntityFramework.Extensions.LicenseManager.AddLicense("6187;101-Apsoft", "c2221180-4596-29f3-c326-d0c443f379a0");
        
        services.RegisterDivisaContext(defaultConnectionString);

        return services;
    }
    
    private static IServiceCollection RegisterDivisaContext(this IServiceCollection services, string domainConnectionString)
    {
        return services.AddDbContext<FinancialDataContext>(option => option
            .UseSqlServer(domainConnectionString, x => { x.MigrationsHistoryTable("__MigrationsHistory", PublicNames.DefaltSchema); }));
    }


}