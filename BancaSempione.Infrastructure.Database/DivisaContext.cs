﻿using BancaSempione.Domain.Boss;
using BancaSempione.Domain.Divise;
using BancaSempione.Infrastructure.Database.Configurations;
using BancaSempione.Infrastructure.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace BancaSempione.Infrastructure.Database;

public class DivisaContext(DbContextOptions<DivisaContext> option) : DbContext(option)
{
    #region Dominio Boss
    public DbSet<DivisaBoss> DivisaBoss { get; set; } = null!;
    public DbSet<CorsoDivisaBoss> CorsoDivisaBoss { get; set; } = null!;
    public DbSet<TabellaBoss> TabellaBoss { get; set; } = null!;
    #endregion

    #region Dominio Sempione
    public DbSet<DivisaRecord> Divisa { get; set; } = null!;
    public DbSet<CorsoDivisaRecord> CorsoDivisa { get; set; } = null!;
    public DbSet<TipoDivisa> TipoDivisa { get; set; } = null!;
    public DbSet<GruppoDivisa> GruppoDivisa { get; set; } = null!;
    #endregion

    #region Logs
    public DbSet<SerilogRow> Logs { get; set; } = null!;
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(PublicNames.DefaltSchema);
        modelBuilder.ApplyConfiguration(new DivisaRecordConfiguration());
        modelBuilder.ApplyConfiguration(new CorsoDivisaRecordConfiguration());
        modelBuilder.ApplyConfiguration(new TipoDivisaConfiguration());
        modelBuilder.ApplyConfiguration(new GruppoDivisaConfiguration());

        modelBuilder.ApplyConfiguration(new CorsoDivisaBossConfiguration());
        modelBuilder.ApplyConfiguration(new DivisaBossConfiguration());
        modelBuilder.ApplyConfiguration(new TabellaBossConfiguration());
    }
}