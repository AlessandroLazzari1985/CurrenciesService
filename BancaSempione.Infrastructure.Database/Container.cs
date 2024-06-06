using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Infrastructure.Database;

public static class Container
{
    public static IServiceCollection BancaSempione_Infrastructure_Database(this IServiceCollection services)
    {
        Z.EntityFramework.Extensions.LicenseManager.AddLicense("6187;101-Apsoft", "c2221180-4596-29f3-c326-d0c443f379a0");

        return services;
    }
}