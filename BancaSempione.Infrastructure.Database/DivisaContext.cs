﻿using BancaSempione.Domain.Divise;
using BancaSempione.Infrastructure.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace BancaSempione.Infrastructure.Database
{
    public class DivisaContext(DbContextOptions<DivisaContext> option) : DbContext(option)
    {
        // public DbSet<BatchLog> BatchLog { get; set; }

        public DbSet<DivisaRecord> Divisa { get; set; } = null!;
        public DbSet<CorsoDivisaRecord> CorsoDivisa { get; set; } = null!;
        public DbSet<TipoDivisa> TipoDivisa { get; set; } = null!;
        public DbSet<GruppoDivisa> GruppoDivisa { get; set; } = null!;

    }
}