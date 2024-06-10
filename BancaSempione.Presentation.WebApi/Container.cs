using Apsoft.Domain.Repositories;
using BancaSempione.Application.Provider.Boss;
using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Database.Logging;
using BancaSempione.Infrastructure.Logging;
using BancaSempione.Infrastructure.Repositories;

namespace BancaSempione.Presentation.Divise.WebApi;

public static class Container
{
    public static IServiceCollection Register_BancaSempione_Presentation_Divise_WebApi(this IServiceCollection serviceCollection, WebApiAppSettings appSettings)
    {
        var serilogSqlServer = SerilogSqlServer.BuildWith(appSettings!.ConnectionStrings.DefaultConnection);

        return serviceCollection
            .AddSingleton(appSettings)

            // Domain
            .Register_Apsoft_Domain_Repositories()

            // Application
            .Register_BancaSempione_Application_Provider_Boss()

            // Infrastructure
            .Register_BancaSempione_Infrastructure_Repositories()
            .Register_BancaSempione_Infrastructure_Logging(serilogSqlServer, appSettings.SerilogMails)
            .Register_BancaSempione_Infrastructure_Database(appSettings.ConnectionStrings.DefaultConnection, appSettings.ConnectionStrings.BossConnection);
    }
}