using BancaSempione.Domain.Divise.Core;

namespace BancaSempione.Domain.Divise;

public class CoppiaDivise(Divisa divisaBase, Divisa divisaContro) : ValueObject<CoppiaDivise>
{
    public Divisa DivisaBase { get; } = divisaBase;
    public Divisa DivisaContro { get; } = divisaContro;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return DivisaBase.AlphabeticCode;
        yield return DivisaContro.AlphabeticCode;
    }
}