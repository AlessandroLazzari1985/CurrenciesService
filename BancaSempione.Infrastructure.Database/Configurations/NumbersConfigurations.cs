using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancaSempione.Infrastructure.Database.Configurations;

public static class NumbersConfigurations
{
    public static PropertyBuilder<TProperty> HasTaglioPrecision<TProperty>(this PropertyBuilder<TProperty> property)
    {
        return property.HasPrecision(5, 0);
    }

    public static PropertyBuilder<TProperty> HasPercentPrecision<TProperty>(this PropertyBuilder<TProperty> property)
    {
        return property.HasPrecision(5, 2);
    }
    
    public static PropertyBuilder<TProperty> HasPerformancePrecision<TProperty>(this PropertyBuilder<TProperty> property)
    {
        return property.HasPrecision(10, 4);
    }

    public static PropertyBuilder<TProperty> HasExchangeRatePrecision<TProperty>(this PropertyBuilder<TProperty> property)
    {
        return property.HasPrecision(20, 6);
    }

    public static PropertyBuilder<TProperty> HasMoneyPrecision<TProperty>(this PropertyBuilder<TProperty> property)
    {
        return property.HasPrecision(18, 4);
    }

    public static PropertyBuilder<TProperty> HasBossPrecisionSixDecimal<TProperty>(this PropertyBuilder<TProperty> property)
    {
        // Boss rappresenta su 15 cifre
        return property.HasPrecision(15, 6);
    }

    public static PropertyBuilder<TProperty> HasBossPrecisionTwoDecimal<TProperty>(this PropertyBuilder<TProperty> property)
    {
        // Boss rappresenta su 15 cifre
        return property.HasPrecision(15, 2);
    }
}

public static class LenthsConfigurations
{
    public static PropertyBuilder<TProperty> HasUtenteBossIdConfiguration<TProperty>(this PropertyBuilder<TProperty> property)
    {
        return property.HasMaxLength(4).IsFixedLength();
    }
}