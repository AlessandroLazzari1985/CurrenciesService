using System.Xml.Serialization;

namespace Apsoft.Application.Provider.CurrencySix.Model;

[XmlRoot("ISO_4217")]
public class Iso4217
{
    [XmlAttribute("Pblshd")]
    public string Published { get; set; }

    [XmlElement("CcyTbl")]
    public CurrencyTable CurrencyTable { get; set; }
}