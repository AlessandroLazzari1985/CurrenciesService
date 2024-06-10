using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Tools.Database.Managers;

public static class Common
{
    public static void CreaDatabaseDataWarehouseContext(string connectionString)
    {
        var providerDestination = new ServiceCollection()
            .RegisterData(connectionString)
            .BuildServiceProvider();

        var destinationContext = providerDestination.GetRequiredService<DataWarehouseContext>();

        MigrationManager.UpdateDatabase(destinationContext);
    }

    /*
    public static void SetTemporalOff(DbContext context, Type tableType)
    {
        var tableName = context.Model.FindEntityType(tableType)?.GetSchemaQualifiedTableName();
        SetTemporalOff(context, tableName!);
    }

    public static void SetTemporalOn(DbContext context, Type tableType)
    {
        var tableName = context.Model.FindEntityType(tableType)?.GetSchemaQualifiedTableName();
        SetTemporalOn(context, tableName!);
    }

    public static List<string> SetTemporalOff(DbContext context, string tableName)
    {
        if(string.IsNullOrWhiteSpace(tableName))
            return new List<string>() { "TableName is empty"};

        var query1 = @$"ALTER TABLE {tableName} SET (SYSTEM_VERSIONING = OFF)";
        var query2 = @$"ALTER TABLE {tableName} DROP PERIOD FOR SYSTEM_TIME";

        var errors = new List<string>();
        try { context.Database.ExecuteSqlRaw(query1); } catch(Exception ex) { errors.Add(ex.Message); }
        try { context.Database.ExecuteSqlRaw(query2); } catch(Exception ex) { errors.Add(ex.Message); }
        return errors;
    }

    public static List<string> SetTemporalOn(DbContext context, string tableName)
    {
        var query3 = @$"ALTER TABLE {tableName} ADD PERIOD FOR SYSTEM_TIME ([PeriodStart], [PeriodEnd])";
        var query4 = @$"ALTER TABLE {tableName} SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE={tableName}History, DATA_CONSISTENCY_CHECK=ON))";

        var errors = new List<string>();
        try { context.Database.ExecuteSqlRaw(query3); } catch(Exception ex) { errors.Add(ex.Message); }
        try { context.Database.ExecuteSqlRaw(query4); } catch(Exception ex) { errors.Add(ex.Message); }
        return errors;
    }


    public static List<string> ReSetTemporal(DbContext context, Type type)
    {
        var tableName = context.Model.FindEntityType(type)?.GetSchemaQualifiedTableName();

        var query1 = @$"ALTER TABLE {tableName} SET (SYSTEM_VERSIONING = OFF)";
        var query2 = @$"ALTER TABLE {tableName} DROP PERIOD FOR SYSTEM_TIME";

        var query3 = @$"ALTER TABLE {tableName} ADD PERIOD FOR SYSTEM_TIME ([PeriodStart], [PeriodEnd])";
        var query4 = @$"ALTER TABLE {tableName} SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE={tableName}History, DATA_CONSISTENCY_CHECK=ON))";

        var errors = new List<string>();
        try { context.Database.ExecuteSqlRaw(query1); } catch(Exception ex) { errors.Add(ex.Message); }
        try { context.Database.ExecuteSqlRaw(query2); } catch(Exception ex) { errors.Add(ex.Message); }
        try { context.Database.ExecuteSqlRaw(query3); } catch (Exception ex) { errors.Add(ex.Message); }
        try { context.Database.ExecuteSqlRaw(query4); } catch (Exception ex) { errors.Add(ex.Message); }

        return errors;
    }

    public static void TruncateTable(DbContext context, string tableName)
    {
        var query = $"TRUNCATE TABLE {tableName}";
        context.Database.ExecuteSqlRaw(query);
    }

    public static void DeleteTable(DbContext context, string tableName)
    {
        var query = $"DELETE FROM {tableName}";
        context.Database.ExecuteSqlRaw(query);
    }

    public static void TruncateTable(DbContext context, Type tableType)
    {
        var tableName = context.Model.FindEntityType(tableType)?.GetSchemaQualifiedTableName();
        TruncateTable(context, tableName!);
    }

    public static void DeleteTable(DbContext context, Type tableType)
    {
        var tableName = context.Model.FindEntityType(tableType)?.GetSchemaQualifiedTableName();
        DeleteTable(context, tableName!);
    }
    */

}