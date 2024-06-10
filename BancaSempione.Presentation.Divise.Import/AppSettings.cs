using BancaSempione.Infrastructure.Logging.Interfaces;

namespace BancaSempione.Presentation.Divise.Import;

public class AppSettings
{
    public ConnectionStrings ConnectionStrings { get; set; } = new();
    public SerilogMails SerilogMails { get; set; } = new();
}

public record SerilogMails : ISerilogMails
{
    public string From { get; } = null!;
    public List<string> To { get; } = new();
}

public class ConnectionStrings
{
    public string DefaultConnection { get; set; } = null!;
}