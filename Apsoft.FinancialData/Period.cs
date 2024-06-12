using Apsoft.Domain.Entities;

namespace Apsoft.Domain.FinancialData;

public class Period : ValueObject<Period>
{
    public DateTime Start { get; }
    public DateTime End { get; }

    public long StartUtc { get; }
    public long EndUtc { get; }

    public Period(DateTime start, DateTime end)
    {
        if (start >= end)
        {
            throw new ArgumentException("ValidFrom deve essere antecedente a ValidTo.");
        }

        Start = start;
        End = end;

        StartUtc = start.ToFileTimeUtc();
        EndUtc = end.ToFileTimeUtc();
    }

    // Metodo per verificare se un dato DateTime cade all'interno del periodo
    public bool Includes(DateTime dateTime)
    {
        return (dateTime >= Start) && (dateTime <= End);
    }
    
    // Metodo per verificare se due periodi si sovrappongono
    public bool OverlapsWith(Period other)
    {
        return Start < other.End && End > other.Start;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}
