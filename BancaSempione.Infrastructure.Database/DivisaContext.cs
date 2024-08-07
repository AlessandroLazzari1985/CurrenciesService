﻿using BancaSempione.Domain.Divise;
using BancaSempione.Infrastructure.Database.Configurations;
using BancaSempione.Infrastructure.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace BancaSempione.Infrastructure.Database;

public class DivisaContext(DbContextOptions<DivisaContext> option) : DbContext(option)
{
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
        modelBuilder.HasDefaultSchema(PublicNames.DiviseSchema);
        modelBuilder.ApplyConfiguration(new DivisaRecordConfiguration());
        modelBuilder.ApplyConfiguration(new CorsoDivisaRecordConfiguration());
        modelBuilder.ApplyConfiguration(new TipoDivisaConfiguration());
        modelBuilder.ApplyConfiguration(new GruppoDivisaConfiguration());
    }
}