using BancaSempione.Domain.Boss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancaSempione.Infrastructure.Database.Configurations;

public class TabellaBossConfiguration : IEntityTypeConfiguration<TabellaBoss>
{
    public void Configure(EntityTypeBuilder<TabellaBoss> entity)
    {
        entity.HasKey(e => new { e.TAB, e.CODE });

        entity.Property(e => e.CODE)
            .HasMaxLength(100)
            .IsUnicode(false);
        entity.Property(e => e.COL_10)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.COL_11)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.COL_12)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.COL_13)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.COL_14)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.COL_15)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.COL_6)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.COL_7)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.COL_8)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.COL_9)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.TAB)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.TEXT_E)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.TEXT_F)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.TEXT_I)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.TEXT_T)
            .HasMaxLength(255)
            .IsUnicode(false);

    }
}