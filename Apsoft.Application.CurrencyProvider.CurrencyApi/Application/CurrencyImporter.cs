using Apsoft.Application.Provider.CurrencyApi.Model;
using Newtonsoft.Json;

namespace Apsoft.Application.Provider.CurrencyApi.Application
{
    public class CurrencyImporter
    {
        private const string DefaultKey = @"cur_live_GK5otV1WJHLoHqN2MhNGuu7PF9cv5rewQMqmzZ0I";
        private const string DefaultUrl = "https://api.currencyapi.com/v3/currencies";

        public async Task<CurrencyDataContainer> Import()
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", DefaultKey);
            var responseString = await httpClient.GetStringAsync(DefaultUrl);
            var currencies = JsonConvert.DeserializeObject<CurrencyDataContainer>(responseString);
            return currencies ?? new CurrencyDataContainer();
        }
    }
}
