namespace BancaSempione.Tools.Database.Enviroments;

public static class ConnectionsStrings
{
    public static class BossServers
    {
        public const string Acceptance = "SBDWLU02\\BDW";
        public const string Production = "SBDWLU01\\BDW";
    }

    public static class DomainServers
    {
        public const string Production = "SSQLLU13\\FAM";
        public const string Acceptance = "SSQLLU12\\Acceptance";
        public const string Testing = "SSQLLU12\\Development";
        public const string Development = "(local)";
    }

    public static class BossDatabase
    {
        public const string DatabaseName = "BSBOSS";
        public const string Production = $"Server={BossServers.Production}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
        public const string Acceptance = $"Server={BossServers.Acceptance}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
        public const string Testing = $"Server={BossServers.Acceptance}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
        public const string Development = $"Server={BossServers.Acceptance}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
    }

    public static class CurrencyDatabase
    {
        public const string DatabaseName = "Divise";
        public const string Production = $"Server={DomainServers.Production}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
        public const string Acceptance = $"Server={DomainServers.Acceptance}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
        public const string Testing = $"Server={DomainServers.Testing}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
        public const string Development = $"Server={DomainServers.Development}; Database={DatabaseName}; Trusted_Connection=True; TrustServerCertificate=True;";
    }
}