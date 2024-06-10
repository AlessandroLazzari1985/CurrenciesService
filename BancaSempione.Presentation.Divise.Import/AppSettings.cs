using BancaSempione.Infrastructure.Logging.Interfaces;

namespace BancaSempione.Presentation.Divise.Import;

public class ImportBatchAppSettings
{
    public ConnectionStrings ConnectionStrings { get; set; } = new();
    public SerilogMails SerilogMails { get; set; } = new();
    public string AllowedHosts { get; set; } = "*";
}

public record SerilogMails : ISerilogMails
{
    public string From { get; } = null!;
    public List<string> To { get; } = new();
}

public class ConnectionStrings
{
    public string DefaultConnection { get; set; } = null!;
    public string BossConnection { get; set; } = null!;
}