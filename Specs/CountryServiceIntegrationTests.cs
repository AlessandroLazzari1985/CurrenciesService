//using Apsoft.Application.Provider.RestCountries.Managers;
//using Xunit.Abstractions;

//namespace Specs;

//public class CountryServiceIntegrationTests(ITestOutputHelper testOutputHelper)
//{
//    [Fact]
//    public async Task GetAllCountriesAsync_ReturnsNonEmptyCountryList()
//    {
//        // Arrange
//        using var httpClient = new HttpClient();
//        var countryService = new CountriesImporter(httpClient);

//        // Act
//        var result = await countryService.GetAllCountriesAsync();

//        // Assert
//        Assert.NotNull(result);
//        Assert.NotEmpty(result);
//    }

//    [Fact]
//    public async Task GetAllCountriesAsync_ReturnsStaticList()
//    {
//        // Arrange
//        using var httpClient = new HttpClient();
//        var countryService = new CountriesImporter(httpClient);

//        // Act
//        var result = await countryService.GetAllCountriesAsync();

//        // Assert
//        Assert.NotNull(result);
//        Assert.NotEmpty(result);

//        result.ForEach(x =>
//        {
//            if(string.IsNullOrWhiteSpace(x.Cca2))
//                return;

//            if (string.IsNullOrWhiteSpace(x.Cca3))
//                return;

//            if (string.IsNullOrWhiteSpace(x.Ccn3))
//                return;

//            if (string.IsNullOrWhiteSpace(x.Name.Common))
//                return;

//            testOutputHelper.WriteLine(@$"        public static readonly Country {x.Cca2} = new(""{x.Name.Common}"", ""{x.Cca2}"", ""{x.Cca3}"", {x.Ccn3});");
//        });

//    }
//}