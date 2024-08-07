﻿using Apsoft.Domain.FinancialData;
using Apsoft.Infrastructure.Database.Configurations;
using Apsoft.Infrastructure.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Apsoft.Infrastructure.Database;

public class FinancialDataContext(DbContextOptions<FinancialDataContext> option) : DbContext(option)
{
    public virtual DbSet<Currency> Currency { get; set; } = null!;
    public virtual DbSet<ActualCurrencyExchangeRate> CurrencyExchangeRates { get; set; } = null!;                       // ExchangeRate delle ultime 24h
    public virtual DbSet<HistoricalCurrencyExchangeRate> HistoricalCurrencyExchangeRates { get; set; } = null!;         // ExchangeRate storici 1 per giorno

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ActualCurrencyExchangeRateConfiguration());
        modelBuilder.ApplyConfiguration(new HistoricalCurrencyExchangeRateConfiguration());
    }
}