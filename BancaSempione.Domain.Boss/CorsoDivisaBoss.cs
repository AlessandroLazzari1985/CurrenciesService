namespace BancaSempione.Domain.Boss;

#pragma warning disable CS8618

// ReSharper disable InconsistentNaming
public class CorsoDivisaBoss
{
    public DateTime DATELA { get; set; }
    public string DIVISA { get; set; }      // varchar(50)
    public double CORSCI { get; set; }      // Corso Interno
    public DateTime VALUCI { get; set; }    // Data Valuta Corso Interno
    public double CORSCR { get; set; }      // Corso Riferimento
    public DateTime VALUCR { get; set; }    // Data Valuta Corso Riferimento
}

#pragma warning restore CS8618