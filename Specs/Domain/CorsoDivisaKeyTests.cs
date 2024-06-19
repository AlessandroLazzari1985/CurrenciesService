using Apsoft.Domain.FinancialData;
using BancaSempione.Domain.Divise;

namespace Specs.Domain;

public class CorsoDivisaKeyTests
{
    [Fact]
    public void SameKey_Equals()
    {
        var eur = Currency.EUR;
        var chf = Currency.CHF;

        var currencyPair = new CurrencyPair(eur, chf);
        var tipoCorsoDivisa = TipoCorsoDivisa.CorsoRiferimento;

        var sut = new CorsoDivisaKey(currencyPair, tipoCorsoDivisa);
        var other = new CorsoDivisaKey(currencyPair, tipoCorsoDivisa);

        Assert.True(sut.Equals(other));
    }
}