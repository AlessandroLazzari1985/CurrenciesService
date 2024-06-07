using BancaSempione.Infrastructure.Logging.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.Email;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.PeriodicBatching;
using System.Collections.ObjectModel;
using System.Data;
using BancaSempione.Infrastructure.Logging.Mails;

namespace BancaSempione.Infrastructure.Logging;

public static class Container
{
    public static IServiceCollection Register_BancaSempione_Infrastructure_Logging(
        this IServiceCollection serviceCollection,
        ISerilogSqlServer serilogSqlServer,
        ISerilogMails serilogMails)
    {
        Log.Logger = new LoggerConfiguration()
            .ConfigureSerilog()
            .AddSqlServer(serilogSqlServer)
            .AddMail(serilogMails)
            .CreateLogger();

        serviceCollection.AddLogging(builder =>
        {
            builder.ClearProviders();                           // Rimuove i provider di logging predefiniti
            builder.AddSerilog(Log.Logger, dispose: true);      // Aggiunge Serilog come provider
        });

        return serviceCollection;
    }

    public static LoggerConfiguration ConfigureSerilog(this LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration 
            .Destructure.ToMaximumDepth(0)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithMachineName()
            .MinimumLevel.Is(LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Cors", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning);
        
        return loggerConfiguration;
    }

    public static LoggerConfiguration AddSqlServer(this LoggerConfiguration loggerConfiguration, ISerilogSqlServer config)
    {
        var columnOptions = new ColumnOptions
        {
            AdditionalColumns = new Collection<SqlColumn>
            {
                new SqlColumn
                    {ColumnName = "ExceptionType", PropertyName = "ExceptionDetail", DataType = SqlDbType.NVarChar, DataLength = -1, AllowNull = true },

                new SqlColumn
                    {ColumnName = "RequestPath", PropertyName = "RequestPath", DataType = SqlDbType.NVarChar, DataLength = -1, AllowNull = true},

                new SqlColumn
                    {ColumnName = "SourceContext", PropertyName = "SourceContext", DataType = SqlDbType.NVarChar, DataLength = -1, AllowNull = true},

                new SqlColumn
                    {ColumnName = "MachineName", PropertyName = "MachineName", DataType = SqlDbType.NVarChar, DataLength = -1, AllowNull = true},
            }
        };

        loggerConfiguration.WriteTo.MSSqlServer(
            connectionString: config.ConnectionString,
            sinkOptions: new MSSqlServerSinkOptions { TableName = config.TableName, SchemaName = config.SchemaName },
            columnOptions: columnOptions);

        return loggerConfiguration;
    }

    public static LoggerConfiguration AddMail(this LoggerConfiguration loggerConfiguration, ISerilogMails serilogMails)
    {
        if (!serilogMails.To.Any())
            return loggerConfiguration;
        
        // var subject = $"{serilogMails.ApplicationName} {serilogMails.Environment}: Fatal Error";
        var configuration = new EmailSinkOptions
        {
            Host = "smtpint.bancasempione.ch",
            // Subject = new ,
            From = serilogMails.From,
            To = serilogMails.To,
            Body = new MyHtmlBodyFormatter(),
            ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true,
            // NetworkCredentials = new NetworkCredential(userName, password, domain)
        };

        loggerConfiguration.WriteTo.Email(
            configuration, 
            new PeriodicBatchingSinkOptions(), 
            LogEventLevel.Information,
            new LoggingLevelSwitch());

        //loggerConfiguration.WriteTo.Email(configuration,
        //    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception:j} {Properties:j}",
        //    restrictedToMinimumLevel: LogEventLevel.Fatal,
        //    mailSubject: subject);

        return loggerConfiguration;
    }
}    
