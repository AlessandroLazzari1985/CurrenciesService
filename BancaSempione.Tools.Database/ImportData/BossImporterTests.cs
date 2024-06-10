using BancaSempione.Application.Provider.Boss;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Tools.Database.ImportData
{
    public class BossImporterTests
    {
        [Fact]
        public void Importa()
        {
            var provider = ToolsContainer.ImportBatch.Development;
            var sut = provider.GetRequiredService<IBossImporter>();

            sut.Importa();
        }
    }
}
