﻿using BancaSempione.Application.DTOs;
using BancaSempione.Application.Provider.Boss;
using BancaSempione.Domain.Services;
using BancaSempione.Infrastructure.Cache;
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

var appSettings = configurationRoot.Get<ImportBatchAppSettings>();
var serilogSqlServer = SerilogSqlServer.BuildWith(appSettings!.ConnectionStrings.DefaultConnection);

var serviceCollection = new ServiceCollection()
    .AddSingleton(appSettings)

    .Register_BancaSempione_Domain_Services()

            // Application
    .Register_BancaSempione_Application_Provider_Boss()
    .Register_BancaSempione_Application_DTOs()

            // Infrastructure
    .Register_BancaSempione_Infrastructure_Cache()
    .Register_BancaSempione_Infrastructure_Repositories()
    .Register_BancaSempione_Infrastructure_Logging(serilogSqlServer, appSettings.SerilogMails)
    .Register_BancaSempione_Infrastructure_Database(appSettings.ConnectionStrings.DefaultConnection, appSettings.ConnectionStrings.BossConnection);


var provider = serviceCollection.BuildServiceProvider();

provider.GetRequiredService<IBossImporter>().Importa();



