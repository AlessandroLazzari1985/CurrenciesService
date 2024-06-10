using BancaSempione.Infrastructure.Database;
using BancaSempione.Infrastructure.Database.Logging;
using BancaSempione.Infrastructure.Logging;
using BancaSempione.Infrastructure.Repositories;
using BancaSempione.Presentation.Divise.Import;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configurationRoot = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var appSettings = configurationRoot.Get<AppSettings>();
var serilogSqlServer = SerilogSqlServer.BuildWith(appSettings!.ConnectionStrings.DefaultConnection);

var serviceCollection = new ServiceCollection()

    // Infrastructure
    .Register_BancaSempione_Infrastructure_Repositories()
    .Register_BancaSempione_Infrastructure_Logging(serilogSqlServer, appSettings.SerilogMails)
    .Register_BancaSempione_Infrastructure_Database(appSettings.ConnectionStrings.DefaultConnection);


var provider = serviceCollection.BuildServiceProvider();





