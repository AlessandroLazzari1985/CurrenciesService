using BancaSempione.Infrastructure.Database;
using BancaSempione.Tools.Database.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Tools.Database;

public class DeployDatabase
{
    [Fact]
    public void Step_Crea_DataWarehouse_Database()
    {
        var provider = ToolsContainer.WebApi.Development;

        var context =  provider.GetRequiredService<DivisaContext>();

        MigrationManager.UpdateDatabase(context);
    }
}