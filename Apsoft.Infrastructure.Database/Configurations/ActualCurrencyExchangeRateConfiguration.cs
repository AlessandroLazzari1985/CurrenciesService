using Apsoft.Infrastructure.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apsoft.Infrastructure.Database.Configurations;

public class ActualCurrencyExchangeRateConfiguration : IEntityTypeConfiguration<ActualCurrencyExchangeRate>
{
    public void Configure(EntityTypeBuilder<ActualCurrencyExchangeRate> builder)
    {
        builder.ToTable(nameof(ActualCurrencyExchangeRate));

        builder.HasKey(c => c.Id);

        builder.Property(c => c.BaseCurrencyCode).ValueGeneratedNever();
        builder.Property(c => c.CounterCurrencyCode).ValueGeneratedNever();
        builder.Property(c => c.BidRate).HasPrecision(18, 6).IsRequired();
        builder.Property(c => c.AskRate).HasPrecision(18, 6).IsRequired();
        builder.Property(c => c.PreviousExchangeRate).HasPrecision(18, 6).IsRequired();

        builder.Property(c => c.ValidFromUtc).IsRequired();
        builder.Property(c => c.ValidFromUtc).IsRequired();

        // Creare un indice combinato su BaseCurrencyCode e CounterCurrencyCode per migliorare le performance delle query
        builder.HasIndex(c => new { c.BaseCurrencyCode, c.CounterCurrencyCode });
    }
}