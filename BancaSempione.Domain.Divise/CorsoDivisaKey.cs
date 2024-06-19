namespace BancaSempione.Domain.Divise;

public class CorsoDivisaKey(CoppiaDivise currencyPair, TipoCorsoDivisa tipoCorsoDivisa) : IEquatable<CorsoDivisaKey>
{
    public CorsoDivisaKey(CorsoDivisa corsoDivisa) : this(corsoDivisa.CoppiaDivise, corsoDivisa.TipoCorsoDivisa) { }

    public CoppiaDivise CurrencyPair { get; } = currencyPair;
    public TipoCorsoDivisa TipoCorsoDivisa { get; } = tipoCorsoDivisa;

    public bool Equals(CorsoDivisaKey? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return CurrencyPair.Equals(other.CurrencyPair) && TipoCorsoDivisa == other.TipoCorsoDivisa;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((CorsoDivisaKey)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CurrencyPair, (int)TipoCorsoDivisa);
    }
}