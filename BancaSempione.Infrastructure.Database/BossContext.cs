using BancaSempione.Domain.Boss;
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


            modelBuilder.Entity<DivisaBoss>().HasKey(s => s.UAUNINUM);
            modelBuilder.Entity<DivisaBoss>().Property(s => s.UAUNINUM).ValueGeneratedNever();
            modelBuilder.Entity<TabellaBoss>().HasKey(s => new { s.TAB, s.CODE });
            modelBuilder.Entity<CorsoDivisaBoss>().HasKey(x => new { x.DATELA, x.DIVISA });
        }
    }
}
