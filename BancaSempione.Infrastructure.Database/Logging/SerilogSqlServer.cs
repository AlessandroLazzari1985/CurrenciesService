using BancaSempione.Infrastructure.Logging.Interfaces;

namespace BancaSempione.Infrastructure.Database.Logging;

public record SerilogSqlServer(string ConnectionString, string SchemaName, string TableName) : ISerilogSqlServer
{
    public static SerilogSqlServer BuildWith(string connectionString) =>
        new SerilogSqlServer(connectionString, PublicNames.DiviseSchema, PublicNames.LogTableName);
}