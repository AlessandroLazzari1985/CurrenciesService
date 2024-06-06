namespace BancaSempione.Domain.Boss;

#pragma warning disable CS8618

// ReSharper disable InconsistentNaming
// TmpADUNIANA
public class DivisaBoss
{
    public decimal UAUNINUM { get; set; }       // Codice BOSS
    public string UACODISO { get; set; }        // Codice ISO
    public string UADES01 { get; set; }
    public string UAGRUPPO { get; set; }        // Gruppo. 0 = Divise principali, 1 = Divise in vita, 2 = Divise non utilizzate
    public string UANAZION { get; set; }        // Nazione di Emissione. EU Europa
    public decimal UADECIMAL { get; set; }      // Numero Decimali
    public decimal UATATAG { get; set; }        // Taglio. Si usare per moltiplicare il cambio ricevuto da BOSS
    public double UAARROTO { get; set; }        // Arrotondamento
    public string UATIPUNI { get; set; }        // Tipo Unita Riguarda i Metalli
}

#pragma warning restore CS8618