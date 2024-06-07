namespace BancaSempione.Infrastructure.Database.Model;

public class SerilogRow
{
    public long Id { get; set; }
    public string? Message { get; set; }
    public string? MessageTemplate { get; set; }
    public string? Level { get; set; }
    public DateTime TimeStamp { get; set; }
    public string? Exception { get; set; }
    public string? Properties { get; set; }
    public string? ExceptionType { get; set; }
    public string? RequestPath { get; set; }
    public string? SourceContext { get; set; }
    public string? MachineName { get; set; }
}