namespace BancaSempione.Infrastructure.Logging.Interfaces;

public interface ISerilogSqlServer
{
    public string ConnectionString { get; }
    public string TableName { get; }
    public string SchemaName { get; }
}