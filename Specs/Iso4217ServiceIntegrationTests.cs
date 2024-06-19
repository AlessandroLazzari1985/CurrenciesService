//using Apsoft.Application.Provider.CurrencyApi.Application;
//using Apsoft.Application.Provider.CurrencySix;

//namespace Specs;

//public class Iso4217ServiceIntegrationTests
//{
//    [Fact]
//    public async Task FetchAndDeserializeIso4217Async_ReturnsValidData()
//    {
//        // Act
//        var sut = new Iso4217Importer();

//        var result = await sut.Import();

//        // Assert
//        Assert.NotNull(result);
//        Assert.NotNull(result.CurrencyTable);
//        Assert.NotNull(result.CurrencyTable.CurrencyCountries);
//    }


//    [Fact]
//    public async Task WriteAllCurrencies()
//    {
//        var isoImporter = new Iso4217Importer();
//        var currencyImporter = new CurrencyImporter();


//    }
//}