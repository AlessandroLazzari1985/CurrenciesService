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

        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.OwnsOne(c => c.CurrencyPair, cp =>
        {
            cp.Property(c => c.BaseCurrency.AlphabeticCode)
                .HasColumnName("BaseCurrencyCode")
                .HasMaxLength(3)
                .IsRequired();

            cp.Property(c => c.CounterCurrency.AlphabeticCode)
                .HasColumnName("CounterCurrencyCode")
                .HasMaxLength(3)
                .IsRequired();
        });

        builder.Property(c => c.ExchangeRate).HasPrecision(18, 6).IsRequired();

        builder.Property(c => c.BidRate).HasPrecision(18, 6).IsRequired();

        builder.Property(c => c.AskRate).HasPrecision(18, 6).IsRequired();

        builder.Property(c => c.Performance).HasPrecision(18, 6).IsRequired();

        //TODO: Eliminare le date quando siamo sicuri dello sviluppo
        builder.Property(c => c.ValidPeriod.Start).IsRequired();
        builder.Property(c => c.ValidPeriod.End).IsRequired();
        builder.Property(c => c.ValidPeriod.StartUtc).IsRequired();
        builder.Property(c => c.ValidPeriod.EndUtc).IsRequired();
    }
}