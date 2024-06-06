using Apsoft.Domain.Entities;

namespace BancaSempione.Domain.Divise;

// TAB N051
public class TipoDivisa : ValueObject<TipoDivisa>
{
    public required string Code { get; set; }
    public string Text { get; set; } = String.Empty;

    public static TipoDivisa Divise = new TipoDivisa { Code = "DV", Text = "Divise" };
    public static TipoDivisa BigliettiBanca = new TipoDivisa { Code = "BB", Text = "Biglietti Banca" };
    public static TipoDivisa MetalliLingottiContabili = new TipoDivisa { Code = "LC", Text = "Metalli Lingotti Contabili" };
    public static TipoDivisa MetalliMoneteContabili = new TipoDivisa { Code = "MC", Text = "Metalli e Monete Contabili" };
    public static TipoDivisa MetalliMoneteFisiche = new TipoDivisa { Code = "MF", Text = "Metalli e Monete fisiche" };
    public static TipoDivisa Diversi = new TipoDivisa { Code = "ZZ", Text = "Diversi" };

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}