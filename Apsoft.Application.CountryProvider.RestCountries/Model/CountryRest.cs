namespace Apsoft.Application.Provider.RestCountries.Model;

public class CountryRest
{
    public required Name Name { get; set; }
    public List<string>? Tld { get; set; }       // Top Level Domain
    public required string Cca2 { get; set; }            // ISO 3166-1 alpha-2 two-letter country codes
    public required string Ccn3 { get; set; }            // ISO 3166-1 numeric code (UN M49)      
    public required string Cca3 { get; set; }            // ISO 3166-1 alpha-3 three-letter country codes
    public string? Cioc { get; set; }
    public bool Independent { get; set; }
    public string? Status { get; set; }
    public bool UnMember { get; set; }
    public Dictionary<string, CurrencyDto>? Currencies { get; set; }
    public Idd? Idd { get; set; }
    public List<string>? Capital { get; set; }
    public List<string>? AltSpellings { get; set; }
    public string Region { get; set; }
    public string Subregion { get; set; }
    public Dictionary<string, string>? Languages { get; set; }
    public Dictionary<string, Translation>? Translations { get; set; } 
    public List<double>? Latlng { get; set; }
    public bool Landlocked { get; set; }
    public List<string>? Borders { get; set; }
    public string Area { get; set; }
    public Dictionary<string, Demonyms>? Demonyms { get; set; }
    public string Flag { get; set; }
    public Maps? Maps { get; set; }
    public int Population { get; set; }
    public Dictionary<string, double>? Gini { get; set; }
    public string? Fifa { get; set; }
    public Car? Car { get; set; }
    public List<string>? Timezones { get; set; }
    public List<string>? Continents { get; set; }
    public Flags? Flags { get; set; }
    public CoatOfArms? CoatOfArms { get; set; }
    public string? StartOfWeek { get; set; }
    public CapitalInfo? CapitalInfo { get; set; }
    public PostalCode? PostalCode { get; set; }
}