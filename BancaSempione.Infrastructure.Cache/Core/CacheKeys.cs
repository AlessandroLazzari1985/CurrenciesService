namespace BancaSempione.Infrastructure.Cache.Core;

public static class CacheKeys
{

    public static class DivisaServiceCacheKeys
    {
        public static string Divise => $"{nameof(CacheKeys)}_{nameof(DivisaServiceCacheKeys)}_{nameof(Divise)}";
        public static string DiviseByIsoCode => $"{nameof(CacheKeys)}_{nameof(DivisaServiceCacheKeys)}_{nameof(DiviseByIsoCode)}";
        public static string DiviseIn => $"{nameof(CacheKeys)}_{nameof(DivisaServiceCacheKeys)}_{nameof(DiviseIn)}";
        public static string DiviseById => $"{nameof(CacheKeys)}_{nameof(DivisaServiceCacheKeys)}_{nameof(DiviseById)}";
        public static string DivisaIstituto => $"{nameof(CacheKeys)}_{nameof(DivisaServiceCacheKeys)}_{nameof(DivisaIstituto)}";
    }

    public static class GruppoDivisaService
    {
        public static string GruppoDivisaById => $"{nameof(CacheKeys)}_{nameof(GruppoDivisaService)}_{nameof(GruppoDivisaById)}";
    }

    public static class TipoDivisaServiceCache
    {
        public static string TipoDivisaById => $"{nameof(CacheKeys)}_{nameof(TipoDivisaServiceCache)}_{nameof(TipoDivisaById)}";
    }


    

}