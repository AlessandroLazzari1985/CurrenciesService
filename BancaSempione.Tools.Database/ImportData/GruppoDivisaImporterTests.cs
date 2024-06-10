using BancaSempione.Application.Provider.Boss.Importers;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Tools.Database.ImportData;

public class GruppoDivisaImporterTests
{
    [Fact]
    public void Importa()
    {
        var provider = ToolsContainer.ImportBatch.Development;
        var sut = provider.GetRequiredService<IGruppoDivisaImporter>();

        sut.Importa();
    }

    [Fact]
    public void Cancella()
    {
        var provider = ToolsContainer.ImportBatch.Development;
        var sut = provider.GetRequiredService<IGruppoDivisaImporter>();

        sut.Cancella();
    }
}