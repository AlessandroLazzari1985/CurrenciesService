using BancaSempione.Domain.Boss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancaSempione.Infrastructure.Database.Configurations;

public class CorsoDivisaBossConfiguration : IEntityTypeConfiguration<CorsoDivisaBoss>
{
    public void Configure(EntityTypeBuilder<CorsoDivisaBoss> builder)
    {
        builder.HasKey(e => new { e.DATELA, e.DIVISA });

    }
}