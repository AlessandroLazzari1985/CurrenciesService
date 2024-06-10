using BancaSempione.Tools.Database.Managers;
using DataWarehouse.Batch.Import;
using DataWarehouse.IntegrationTests.Consts;

namespace DataWarehouse.IntegrationTests;

public class DeployDatabase
{
    [Fact]
    public void Step_Crea_DataWarehouse_Database()
    {
        Common.CreaDatabaseDataWarehouseContext(ConnectionsStrings.DataWarehouse.Production);
    }

    [Fact]
    public void RunImportBatch()
    {
        var provider = TestContainer.Production();
        Execute.Run(provider);
    }
}