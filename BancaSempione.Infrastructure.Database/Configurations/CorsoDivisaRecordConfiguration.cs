using BancaSempione.Infrastructure.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancaSempione.Infrastructure.Database.Configurations;

public class CorsoDivisaRecordConfiguration : IEntityTypeConfiguration<CorsoDivisaRecord>
{
    public void Configure(EntityTypeBuilder<CorsoDivisaRecord> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.BaseCurrencyCode).ValueGeneratedNever();
        builder.Property(c => c.CounterCurrencyCode).ValueGeneratedNever();
        builder.Property(c => c.BidRate).HasPrecision(18, 6).IsRequired();
        builder.Property(c => c.AskRate).HasPrecision(18, 6).IsRequired();
        builder.Property(c => c.PreviousExchangeRate).HasPrecision(18, 6).IsRequired();

        builder.Property(c => c.ValidFromUtc).IsRequired();
        builder.Property(c => c.ValidToUtc).IsRequired();

        // Creare un indice combinato su BaseCurrencyCode e CounterCurrencyCode per migliorare le performance delle query
        builder.HasIndex(c => new { c.BaseCurrencyCode, c.CounterCurrencyCode, c.TipoCorsoDivisa, c.ValidFromUtc }).IsUnique();
        builder.HasIndex(c => new { c.BaseCurrencyCode, c.CounterCurrencyCode, c.TipoCorsoDivisa });
    }
}