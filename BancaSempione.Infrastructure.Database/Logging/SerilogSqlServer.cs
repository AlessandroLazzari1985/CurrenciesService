using BancaSempione.Infrastructure.Logging.Interfaces;

namespace BancaSempione.Infrastructure.Database.Logging;

public record SerilogSqlServer(string ConnectionString, string TableName, string SchemaName) : ISerilogSqlServer
{
    public static SerilogSqlServer BuildWith(string connectionString) =>
        new SerilogSqlServer(connectionString, PublicNames.DefaltSchema, PublicNames.LogTableName);
}