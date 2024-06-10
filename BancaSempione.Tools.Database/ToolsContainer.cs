using BancaSempione.Presentation.Divise.Import;
using BancaSempione.Presentation.Divise.WebApi;
using BancaSempione.Tools.Database.Enviroments;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Tools.Database
{
    public static class ToolsContainer
    {
        public static class WebApi
        {
            public static ServiceProvider Production => GetImportBatchServiceProvider(WebApiAppSettingsCollection.Production);
            public static ServiceProvider Acceptance => GetImportBatchServiceProvider(WebApiAppSettingsCollection.Acceptance);
            public static ServiceProvider Testing => GetImportBatchServiceProvider(WebApiAppSettingsCollection.Testing);
            public static ServiceProvider Development => GetImportBatchServiceProvider(WebApiAppSettingsCollection.Development);

            private static ServiceProvider GetImportBatchServiceProvider(WebApiAppSettings appSettings)
            {
                return new ServiceCollection()
                    .Register_BancaSempione_Presentation_Divise_WebApi(appSettings)
                    .BuildServiceProvider();
            }
        }

        public static class ImportBatch
        {
            public static ServiceProvider Production => GetImportBatchServiceProvider(ImportBatchAppSettingsCollection.Production);
            public static ServiceProvider Acceptance => GetImportBatchServiceProvider(ImportBatchAppSettingsCollection.Acceptance);
            public static ServiceProvider Testing => GetImportBatchServiceProvider(ImportBatchAppSettingsCollection.Testing);
            public static ServiceProvider Development => GetImportBatchServiceProvider(ImportBatchAppSettingsCollection.Development);

            private static ServiceProvider GetImportBatchServiceProvider(ImportBatchAppSettings appSettings)
            {
                return new ServiceCollection()
                    .Register_BancaSempione_Presentation_Divise_Import(appSettings)
                    .BuildServiceProvider();
            }

        }
    }
}
