using BancaSempione.Application.Provider.Boss;
using BancaSempione.Domain.Services;
using BancaSempione.Infrastructure.Cache;
using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Database.Logging;
using BancaSempione.Infrastructure.Logging;
using BancaSempione.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Presentation.Divise.Import;

public static class Container
{
    public static IServiceCollection Register_BancaSempione_Presentation_Divise_Import(this IServiceCollection serviceCollection, ImportBatchAppSettings appSettings)
    {
        var serilogSqlServer = SerilogSqlServer.BuildWith(appSettings!.ConnectionStrings.DefaultConnection);

        return serviceCollection
            .AddSingleton(appSettings)

            // Domain
            .Register_BancaSempione_Domain_Services()

            // Application
            .Register_BancaSempione_Application_Provider_Boss()

            // Infrastructure
            .Register_BancaSempione_Infrastructure_Cache()
            .Register_BancaSempione_Infrastructure_Repositories()
            .Register_BancaSempione_Infrastructure_Logging(serilogSqlServer, appSettings.SerilogMails)
            .Register_BancaSempione_Infrastructure_Database(appSettings.ConnectionStrings.DefaultConnection, appSettings.ConnectionStrings.BossConnection);
    }
}