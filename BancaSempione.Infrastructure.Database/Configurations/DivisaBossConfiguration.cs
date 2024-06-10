using BancaSempione.Domain.Boss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancaSempione.Infrastructure.Database.Configurations;

public class DivisaBossConfiguration : IEntityTypeConfiguration<DivisaBoss>
{
    public void Configure(EntityTypeBuilder<DivisaBoss> builder)
    {
        builder.HasKey(e => e.UAUNINUM);
        builder.Property(e => e.UACODISO).HasMaxLength(10);
        builder.Property(e => e.UACODISO).HasMaxLength(10);

    }
}