using BancaSempione.Domain.Divise;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancaSempione.Infrastructure.Database.Configurations;

public class GruppoDivisaConfiguration : IEntityTypeConfiguration<GruppoDivisa>
{
    public void Configure(EntityTypeBuilder<GruppoDivisa> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedNever();
        builder.Property(g => g.Text).HasMaxLength(50);
    }
}