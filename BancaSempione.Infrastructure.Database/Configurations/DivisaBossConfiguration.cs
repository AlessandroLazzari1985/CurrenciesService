using BancaSempione.Domain.Boss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancaSempione.Infrastructure.Database.Configurations;

public class DivisaBossConfiguration : IEntityTypeConfiguration<DivisaBoss>
{
    public void Configure(EntityTypeBuilder<DivisaBoss> entity)
    {
        entity.HasKey(e => e.UAUNINUM);
        
        // 
        entity.Property(e => e.CMERCLIB)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.CODE)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UACODBA)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UACODISO)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UACODTK)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UADECIMAL).HasColumnType("numeric(20, 0)");
        entity.Property(e => e.UADES01)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UADES02)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UADES03)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UADES04)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UADESABB)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UADIRTAS)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UAGRUPPO)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UANAZION)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UAPERCOP)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UASTPUNI)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UATATAG).HasColumnType("numeric(20, 0)");
        entity.Property(e => e.UATIPUNI)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UAUNIMIS)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.UAUNINUM).HasColumnType("numeric(20, 0)");
        entity.Property(e => e.UAUSANZA)
            .HasMaxLength(50)
            .IsUnicode(false);

    }
}