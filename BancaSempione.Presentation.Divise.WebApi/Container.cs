using BancaSempione.Application.DTOs;
using BancaSempione.Application.Provider.Boss;
using BancaSempione.Domain.Services;
using BancaSempione.Infrastructure.Cache;
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

            // Domain ------------------------------------------------------------
            // Apsoft
            // .Register_Apsoft_Domain_Services()

            // Sempione
            .Register_BancaSempione_Domain_Services()

            // Application ------------------------------------------------------------

            // Sempione
            .Register_BancaSempione_Application_Provider_Boss()
            .Register_BancaSempione_Application_DTOs()

            // Infrastructure ------------------------------------------------------------

            // Apsoft
            // .Register_Apsoft_Infrastructure_Database(appSettings.ConnectionStrings.DefaultConnection)
            // .Register_Apsoft_Infrastructure_Repositories()

            // BancaSempione
            .Register_BancaSempione_Infrastructure_Cache()
            .Register_BancaSempione_Infrastructure_Repositories()
            .Register_BancaSempione_Infrastructure_Logging(serilogSqlServer, appSettings.SerilogMails)
            .Register_BancaSempione_Infrastructure_Database(appSettings.ConnectionStrings.DefaultConnection, appSettings.ConnectionStrings.BossConnection);
    }
}