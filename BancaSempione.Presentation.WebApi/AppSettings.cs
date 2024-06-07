using BancaSempione.Infrastructure.Logging.Interfaces;

namespace BancaSempione.Presentation.Divise.WebApi;

public class AppSettings : ISerilogConfiguration
{
    public ConnectionStrings ConnectionStrings { get; set; } = new();
}

public class ConnectionStrings
{
    public string DefaultConnection { get; set; } = null!;
}