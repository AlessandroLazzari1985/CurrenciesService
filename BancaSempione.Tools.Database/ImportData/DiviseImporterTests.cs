using BancaSempione.Application.Provider.Boss;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Tools.Database.ImportData;

public class DiviseImporterTests
{
    [Fact]
    public void ImportDivise()
    {
        var provider = ToolsContainer.ImportBatch.Development;
        var sut = provider.GetRequiredService<IDivisaImporter>();

        sut.ImportaDiviseDaBoss();
    }

    [Fact]
    public void CancellaDivise()
    {
        var provider = ToolsContainer.ImportBatch.Development;
        var sut = provider.GetRequiredService<IDivisaImporter>();

        sut.CancellaDivise();
    }
}