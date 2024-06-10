using BancaSempione.Presentation.Divise.WebApi;

namespace BancaSempione.Tools.Database.Enviroments;

public static class WebApiAppSettingsCollection
{
    public static WebApiAppSettings Development = new()
    {
        AllowedHosts = "http://localhost:4200",
        ConnectionStrings = new ConnectionStrings
        {
            DefaultConnection = ConnectionsStrings.CurrencyDatabase.Development,
            BossConnection = ConnectionsStrings.BossDatabase.Development,
        }
    };

    public static WebApiAppSettings Testing = new()
    {
        AllowedHosts = "http://localhost:4200",
        ConnectionStrings = new ConnectionStrings
        {
            DefaultConnection = ConnectionsStrings.CurrencyDatabase.Testing,
            BossConnection = ConnectionsStrings.BossDatabase.Testing,
        }
    };

    public static WebApiAppSettings Acceptance = new()
    {
        AllowedHosts = "http://localhost:4200",
        ConnectionStrings = new ConnectionStrings
        {
            DefaultConnection = ConnectionsStrings.CurrencyDatabase.Acceptance,
            BossConnection = ConnectionsStrings.BossDatabase.Acceptance,
        }
    };

    public static WebApiAppSettings Production = new()
    {
        AllowedHosts = "http://localhost:4200",
        ConnectionStrings = new ConnectionStrings
        {
            DefaultConnection = ConnectionsStrings.CurrencyDatabase.Production,
            BossConnection = ConnectionsStrings.BossDatabase.Production,
        }
    };
}