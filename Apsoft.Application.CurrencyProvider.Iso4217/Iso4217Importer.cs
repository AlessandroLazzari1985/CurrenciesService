using System.Xml.Serialization;
using Apsoft.Application.Provider.CurrencySix.Model;

namespace Apsoft.Application.Provider.CurrencySix
{
    public class Iso4217Importer
    {
        private const string XmlUrl = @"https://www.six-group.com/dam/download/financial-information/data-center/iso-currrency/lists/list-one.xml";

        public async Task<Iso4217?> Import()
        {
            using var httpClient = new HttpClient();
            var stream = await httpClient.GetStreamAsync(XmlUrl);

            XmlSerializer serializer = new XmlSerializer(typeof(Iso4217));

            var result = serializer.Deserialize(stream) as Iso4217;

            return result;
        }
    }
}
