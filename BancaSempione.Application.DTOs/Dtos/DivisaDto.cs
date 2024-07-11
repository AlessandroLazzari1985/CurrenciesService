namespace BancaSempione.Application.DTOs.Dtos;

public class DivisaDto
{
    public int DivisaId { get; set; }
    public string AlphabeticCode { get; set; } = null!;
    public int NumericCode { get; set; }
    public string? Name { get; set; }
    public string? Symbol { get; set; }
    public int DecimalDigits { get; set; }
    public int Rounding { get; set; }
    public bool IsDivisaIn { get; set; }
    public decimal Taglio { get; set; }
    public int GruppoDivisaId { get; set; }
    public string TipoDivisaId { get; set; } = null!;
}