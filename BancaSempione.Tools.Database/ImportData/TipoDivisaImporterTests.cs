using BancaSempione.Application.Provider.Boss.Importers;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Tools.Database.ImportData;

public class TipoDivisaImporterTests
{
    [Fact]
    public void Importa()
    {
        var provider = ToolsContainer.ImportBatch.Development;
        var sut = provider.GetRequiredService<ITipoDivisaImporter>();

        sut.Importa();
    }

    [Fact]
    public void Cancella()
    {
        var provider = ToolsContainer.ImportBatch.Development;
        var sut = provider.GetRequiredService<ITipoDivisaImporter>();

        sut.Cancella();
    }
}