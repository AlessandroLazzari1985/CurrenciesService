using BancaSempione.Infrastructure.Logging.Interfaces;

namespace BancaSempione.Presentation.Divise.WebApi;

public class WebApiAppSettings
{
    public ConnectionStrings ConnectionStrings { get; set; } = new();
    public SerilogMails SerilogMails { get; set; } = new();
    public string AllowedHosts { get; set; } = String.Empty;
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