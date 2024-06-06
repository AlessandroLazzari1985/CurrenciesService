using Apsoft.Domain.Entities;

namespace BancaSempione.Domain.Divise;

// TAB N051
public class TipoDivisa : ValueObject<TipoDivisa>
{
    public required string Id { get; set; }
    public string Text { get; set; } = String.Empty;

    public static TipoDivisa Divise = new TipoDivisa { Id = "DV", Text = "Divise" };
    public static TipoDivisa BigliettiBanca = new TipoDivisa { Id = "BB", Text = "Biglietti Banca" };
    public static TipoDivisa MetalliLingottiContabili = new TipoDivisa { Id = "LC", Text = "Metalli Lingotti Contabili" };
    public static TipoDivisa MetalliMoneteContabili = new TipoDivisa { Id = "MC", Text = "Metalli e Monete Contabili" };
    public static TipoDivisa MetalliMoneteFisiche = new TipoDivisa { Id = "MF", Text = "Metalli e Monete fisiche" };
    public static TipoDivisa Diversi = new TipoDivisa { Id = "ZZ", Text = "Diversi" };

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}