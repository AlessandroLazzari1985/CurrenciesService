using Microsoft.EntityFrameworkCore.Migrations;

namespace BancaSempione.Tools.Database.Managers;

public static class MigrationManager
{
    public static void UpdateDatabase(DataWarehouseContext context)
    {
        // Creazione/Aggiornamento del database
        context.GetInfrastructure().GetService<IMigrator>()?.Migrate();

        if (context.Database.EnsureCreated())
        {
            var querySetRecoveryMode = $"ALTER DATABASE [{context.Database.GetDbConnection().Database}] SET RECOVERY SIMPLE";
            context.Database.ExecuteSqlRaw(querySetRecoveryMode);
        }
    }

    public static void DowngradeDatabase(DataWarehouseContext context)
    {
        context.GetInfrastructure().GetService<IMigrator>()?.Migrate("0");
    }
}