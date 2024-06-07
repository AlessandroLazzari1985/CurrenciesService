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

namespace BancaSempione.Infrastructure.Logging;

public static class Container
{
    public static IServiceCollection Register_BancaSempione_Infrastructure_Logging(
        this IServiceCollection serviceCollection, 
        ISerilogConfiguration serilogConfiguration)
    {
        Log.Logger = ConfigureSerilog(serilogConfiguration).CreateLogger();

        serviceCollection.AddLogging(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Information);
        });

        return serviceCollection;
    }

    private static LoggerConfiguration ConfigureSerilog(ISerilogConfiguration serilogConfiguration)
    {
        var loggerConfiguration = new LoggerConfiguration()
            .Destructure.ToMaximumDepth(0)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithMachineName();

        loggerConfiguration.MinimumLevel.Is(LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Cors", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning);

        loggerConfiguration
            .AddSqlServer(serilogConfiguration)
            .AddMail(serilogConfiguration);

        return loggerConfiguration;
    }

    public static LoggerConfiguration AddSqlServer(this LoggerConfiguration loggerConfiguration, ISerilogSqlServer serilogSqlServer)
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
            connectionString: serilogSqlServer.ConnectionString,
            sinkOptions: new MSSqlServerSinkOptions { TableName = serilogSqlServer.TableName, SchemaName = serilogSqlServer.SchemaName },
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
