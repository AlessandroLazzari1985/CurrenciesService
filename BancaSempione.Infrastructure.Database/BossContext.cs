using BancaSempione.Domain.Boss;
using BancaSempione.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BancaSempione.Infrastructure.Database
{
    public class BossContext(DbContextOptions<BossContext> option) : DbContext(option)
    {
        public virtual DbSet<DivisaBoss> DivisaBoss { get; set; } = null!;
        public virtual DbSet<TabellaBoss> TabellaBoss { get; set; } = null!;
        public virtual DbSet<CorsoDivisaBoss> CorsoDivisaBoss { get; set; } = null!;      // TmpDivisaCorso Ogni giorno vengono scaricati i corsi divisa


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DivisaBoss>().ToTable("TmpADUNIANA");
            modelBuilder.Entity<TabellaBoss>().ToTable("TmpTABELLE");
            modelBuilder.Entity<CorsoDivisaBoss>().ToTable("TmpDivisaCorso");
            
            modelBuilder.ApplyConfiguration(new CorsoDivisaBossConfiguration());
            modelBuilder.ApplyConfiguration(new DivisaBossConfiguration());
            modelBuilder.ApplyConfiguration(new TabellaBossConfiguration());
        }
    }
}
