using BancaSempione.Application.Provider.Boss.Importers.ImportCorsoDivisa;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Tools.Database.ImportData;

public class CorsoDivisaImporterTests
{
    [Fact]
    public void Importa()
    {
        var provider = ToolsContainer.ImportBatch.Development;
        var sut = provider.GetRequiredService<ICorsoDivisaImporter>();

        sut.Importa();
    }

    [Fact]
    public void Cancella()
    {
        var provider = ToolsContainer.ImportBatch.Development;
        var sut = provider.GetRequiredService<ICorsoDivisaImporter>();

        sut.Cancella();
    }
}