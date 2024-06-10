using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Tools.Database.Managers;

public static class MigrationManager
{
    public static void UpdateDatabase(DbContext context)
    {
        // Creazione/Aggiornamento del database
        context.GetInfrastructure().GetService<IMigrator>()?.Migrate();

        if (context.Database.EnsureCreated())
        {
            var querySetRecoveryMode = $"ALTER DATABASE [{context.Database.GetDbConnection().Database}] SET RECOVERY SIMPLE";
            context.Database.ExecuteSqlRaw(querySetRecoveryMode);
        }
    }

    public static void DowngradeDatabase(DbContext context)
    {
        context.GetInfrastructure().GetService<IMigrator>()?.Migrate("0");
    }
}