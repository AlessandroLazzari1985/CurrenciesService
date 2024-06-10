using BancaSempione.Presentation.Divise.Import;

namespace BancaSempione.Tools.Database.Enviroments;

public static class ImportBatchAppSettingsCollection
{

    public static ImportBatchAppSettings Development = new()
    {
        AllowedHosts = "http://localhost:4200",
        ConnectionStrings = new ConnectionStrings
        {
            DefaultConnection = ConnectionsStrings.CurrencyDatabase.Development,
            BossConnection = ConnectionsStrings.BossDatabase.Development,
        }
    };

    public static ImportBatchAppSettings Testing = new()
    {
        AllowedHosts = "http://localhost:4200",
        ConnectionStrings = new ConnectionStrings
        {
            DefaultConnection = ConnectionsStrings.CurrencyDatabase.Testing,
            BossConnection = ConnectionsStrings.BossDatabase.Testing,
        }
    };

    public static ImportBatchAppSettings Acceptance = new()
    {
        AllowedHosts = "http://localhost:4200",
        ConnectionStrings = new ConnectionStrings
        {
            DefaultConnection = ConnectionsStrings.CurrencyDatabase.Acceptance,
            BossConnection = ConnectionsStrings.BossDatabase.Acceptance,
        }
    };

    public static ImportBatchAppSettings Production = new()
    {
        AllowedHosts = "http://localhost:4200",
        ConnectionStrings = new ConnectionStrings
        {
            DefaultConnection = ConnectionsStrings.CurrencyDatabase.Production,
            BossConnection = ConnectionsStrings.BossDatabase.Production,
        }
    };

}