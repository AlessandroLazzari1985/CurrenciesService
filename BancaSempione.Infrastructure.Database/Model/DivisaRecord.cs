namespace BancaSempione.Infrastructure.Database.Model
{
    public class DivisaRecord
    {
        public int DivisaRecordId { get; set; }
        public string AlphabeticCode { get; set; }
        public int NumericCode { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public int DecimalDigits { get; set; }
        public int Rounding { get; set; }
        public bool IsDivisaIn { get; set; }
        public decimal Taglio { get; set; }
        public int GruppoDivisaCode { get; set; }
        public string TipoDivisaCode { get; set; }
    }

}
