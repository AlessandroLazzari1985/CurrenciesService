using Apsoft.Application.Provider.RestCountries.Model;
using Newtonsoft.Json;

namespace Apsoft.Application.Provider.RestCountries.Managers;

public class CountriesImporter(HttpClient httpClient)
{
    private const string BaseUrl = "https://restcountries.com/v3.1/all";

    public async Task<List<CountryRest>> GetAllCountriesAsync()
    {
        try
        {
            var response = await httpClient.GetStringAsync(BaseUrl);
            var countries = JsonConvert.DeserializeObject<List<CountryRest>>(response);
            return countries;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<CountryRest>();
        }
    }
}