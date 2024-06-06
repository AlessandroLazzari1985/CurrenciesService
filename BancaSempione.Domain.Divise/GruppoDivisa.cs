using Apsoft.Domain.Entities;

namespace BancaSempione.Domain.Divise;

public class GruppoDivisa: ValueObject<GruppoDivisa>
{
    public int Code { get; set; }
    public string Text { get; set; } = string.Empty;
    
    public static GruppoDivisa Principali = new GruppoDivisa { Code = 0, Text = "Principali" };
    public static GruppoDivisa Utilizzate = new GruppoDivisa { Code = 1, Text = "Utilizzate" };
    public static GruppoDivisa NonUtilizzate = new GruppoDivisa { Code = 2, Text = "NonUtilizzate" };

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}