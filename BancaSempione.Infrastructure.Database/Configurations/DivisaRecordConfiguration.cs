using BancaSempione.Infrastructure.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancaSempione.Infrastructure.Database.Configurations;

public class DivisaRecordConfiguration : IEntityTypeConfiguration<DivisaRecord>
{
    public void Configure(EntityTypeBuilder<DivisaRecord> builder)
    {
        builder.HasKey(e => e.DivisaRecordId);

        builder.Property(e => e.AlphabeticCode).IsRequired().HasMaxLength(3);

        builder.Property(e => e.NumericCode).IsRequired();

        builder.Property(e => e.Name).HasMaxLength(100);

        builder.Property(e => e.Symbol).HasMaxLength(10);

        builder.Property(e => e.DecimalDigits).IsRequired();

        builder.Property(e => e.Rounding).IsRequired();

        builder.Property(e => e.IsDivisaIn).IsRequired();

        builder.Property(e => e.Taglio).HasPrecision(18, 2);        // Vale 1, 100 o 1000. L'ho lasciato con 2 decimali per essere aperto a fantasie future

        builder.Property(e => e.GruppoDivisaId).IsRequired();

        builder.Property(e => e.TipoDivisaId).IsRequired().HasMaxLength(2);

        builder.HasIndex(e => e.AlphabeticCode).IsUnique();
        builder.HasIndex(e => e.NumericCode).IsUnique();
    }
}