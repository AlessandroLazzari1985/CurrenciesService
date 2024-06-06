using System.Xml.Serialization;

namespace Apsoft.Application.Provider.CurrencySix.Model;

public class CurrencyTable
{
    [XmlElement("CcyNtry")]
    public List<CurrencyCountry> CurrencyCountries { get; set; } = new();
}