using Apsoft.Domain.FinancialData;

namespace Specs;

public class CountryRestTests
{
    [Fact]
    public void Countries_WithSameValues_AreEqual()
    {
        var country1 = new Country("Italy", "IT", "ITA", 380);
        var country2 = new Country("Italy", "IT", "ITA", 380);

        Assert.True(country1 == country2);
    }

    [Fact]
    public void Countries_WithDifferentValues_AreNotEqual()
    {
        var country1 = new Country("Italy", "IT", "ITA", 380);
        var country2 = new Country("Spain", "ES", "ESP", 724);

        Assert.True(country1 != country2);
    }

    [Fact]
    public void Country_IsEqualToItself()
    {
        var country = new Country("Italy", "IT", "ITA", 380);

        Assert.True(country == country);
    }

    [Fact]
    public void Country_IsNotEqualToNull()
    {
        var country = new Country("Italy", "IT", "ITA", 380);

        Assert.False(country == null);
    }

    [Fact]
    public void PredefinedCountries_AreEqualOrNotEqual_Correctly()
    {
        Assert.True(Country.IT != Country.ES);
        Assert.False(Country.IT == Country.ES);

        // Correzione dell'errore nell'ISO Alpha 2 di Spain
        var correctedESP = new Country("Spain", "ES", "ESP", 724);
        Assert.True(Country.ES == correctedESP);
    }

    [Fact]
    public void GetAllStaticInstances_ReturnsAllStaticInstances()
    {
        // Act
        var countries = Currency.GetAll();

        // Assert
        Assert.NotEmpty(countries); // Assure that the list is not empty
        Assert.All(countries, x => Assert.IsType<Country>(x)); // Assure that all elements are of type Currency
    }
}