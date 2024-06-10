namespace BancaSempione.Tools.Database.Enviroments;


public static class DatabaseServer
{
    public static class Boss
    {
        public const string Acceptance = "SBDWLU02\\BDW";
        public const string Production = "SBDWLU01\\BDW";
    }

    public static class Domain
    {
        public const string Production = "SSQLLU13\\FAM";
        public const string Acceptance = "SSQLLU12\\Acceptance";
        public const string Testing = "SSQLLU12\\Development";
        public const string Development = "(local)";
    }
}

public static class ConnectionsStrings
{
    
    public static class BossDatabase
    {
        public const string DatabaseName = "BSBOSS";
        public const string Production = $"Server={DatabaseServer.Boss.Production}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
        public const string Acceptance = $"Server={DatabaseServer.Boss.Acceptance}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
        public const string Testing = $"Server={DatabaseServer.Boss.Acceptance}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
        public const string Development = $"Server={DatabaseServer.Boss.Acceptance}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
    }

    public static class CurrencyDatabase
    {
        public const string DatabaseName = "Divise";
        public const string Production = $"Server={DatabaseServer.Domain.Production}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
        public const string Acceptance = $"Server={DatabaseServer.Domain.Acceptance}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
        public const string Testing = $"Server={DatabaseServer.Domain.Testing}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
        public const string Development = $"Server={DatabaseServer.Domain.Development}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
    }
}