using BancaSempione.Domain.Boss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancaSempione.Infrastructure.Database.Configurations;

public class TabellaBossConfiguration : IEntityTypeConfiguration<TabellaBoss>
{
    public void Configure(EntityTypeBuilder<TabellaBoss> builder)
    {
        builder.HasKey(e => new { e.TAB, e.CODE });

    }
}