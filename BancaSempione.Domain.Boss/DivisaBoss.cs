namespace BancaSempione.Domain.Boss;

#pragma warning disable CS8618

// ReSharper disable InconsistentNaming
// TmpADUNIANA
public class DivisaBoss
{
    public string? CODE { get; set; }
    public decimal UAUNINUM { get; set; }       // Codice BOSS
    public string UATIPUNI { get; set; }        // Tipo Unita Riguarda i Metalli
    public string? UADESABB { get; set; }
    public string UACODISO { get; set; }        // Codice ISO
    public string UADES01 { get; set; }
    public string? UADES02 { get; set; }
    public string? UADES03 { get; set; }
    public string? UADES04 { get; set; }
    public string UAGRUPPO { get; set; }        // Gruppo. 0 = Divise principali, 1 = Divise in vita, 2 = Divise non utilizzate
    public string UANAZION { get; set; }        // Nazione di Emissione. EU Europa
    public string? UAUSANZA { get; set; }
    public decimal UADECIMAL { get; set; }      // Numero Decimali
    public decimal UATATAG { get; set; }        // Taglio. Si usare per moltiplicare il cambio ricevuto da BOSS
    public double UAARROTO { get; set; }        // Arrotondamento
    public string? UADIRTAS { get; set; }
    public string? UAPERCOP { get; set; }
    public string? CMERCLIB { get; set; }
    public string? UASTPUNI { get; set; }
    public string? UAUNIMIS { get; set; }
    public string? UACODBA { get; set; }
    public string? UACODTK { get; set; }
}

#pragma warning restore CS8618