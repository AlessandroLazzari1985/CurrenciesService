using System.Xml.Serialization;

namespace Apsoft.Application.Provider.CurrencySix.Model;

public class CurrencyCountry
{
    [XmlElement("CtryNm")]
    public string CountryName { get; set; }

    [XmlAttribute("IsFund")]
    public bool IsFund { get; set; }

    [XmlElement("CcyNm")]
    public string CurrencyName { get; set; }

    [XmlElement("Ccy")]
    public string Currency { get; set; }

    [XmlElement("CcyNbr")]
    public string CurrencyNumber { get; set; }

    [XmlElement("CcyMnrUnts")]
    public string CurrencyMinorUnits { get; set; }
}