using BancaSempione.Infrastructure.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancaSempione.Infrastructure.Database.Configurations;

public class CorsoDivisaRecordConfiguration : IEntityTypeConfiguration<CorsoDivisaRecord>
{
    public void Configure(EntityTypeBuilder<CorsoDivisaRecord> builder)
    {
        builder.HasKey(e => e.CorsoDivisaRecordId);

        builder.Property(e => e.BaseDivisaId).IsRequired();

        builder.Property(e => e.CounterDivisaId).IsRequired();

        builder.Property(e => e.ExchangeRate).HasExchangeRatePrecision().IsRequired();

        builder.Property(e => e.BidRate).HasExchangeRatePrecision().IsRequired();

        builder.Property(e => e.AskRate).HasExchangeRatePrecision().IsRequired();

        builder.Property(e => e.Performance).HasPerformancePrecision().IsRequired();

        builder.Property(e => e.Spread).HasPerformancePrecision().IsRequired();

        builder.Property(e => e.ValidFrom).IsRequired();

        builder.Property(e => e.ValidTo).IsRequired();

        builder.Property(e => e.ValidFromUtc).IsRequired();

        builder.Property(e => e.ValidToUtc).IsRequired();

        // Indici aggiuntivi per ottimizzare le query
        builder.HasIndex(e => new { e.BaseDivisaId, e.CounterDivisaId, e.ValidFrom }).IsUnique();
        builder.HasIndex(e => e.ValidFromUtc);
        builder.HasIndex(e => e.ValidToUtc);
        builder.HasIndex(e => new { e.ValidFromUtc, e.ValidToUtc });
    }
}