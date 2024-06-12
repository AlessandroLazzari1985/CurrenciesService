using Apsoft.Domain.FinancialData;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BancaSempione.Tools.Database.Repositories;

public class RepositoriesTests
{
    [Fact]
    public void Read_CordoDivisa()
    {
        // Arrange
        var provider = ToolsContainer.ImportBatch.Development;
        var sut = provider.GetRequiredService<ICorsoDivisaRepository>();

        // Act

        var currencyPair = new CurrencyPair(Currency.EUR, Currency.CHF);
        var corsiDivisa = sut.Items.Where(x => x.CurrencyExchangeRate.CurrencyPair == currencyPair && x.TipoCorsoDivisa == TipoCorsoDivisa.CorsoRiferimento).ToList();

        // Assert
        Assert.NotEmpty(corsiDivisa);
    }
}