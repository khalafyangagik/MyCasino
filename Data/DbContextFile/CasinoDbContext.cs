using Casino.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DbContextFile
{
    public class CasinoDbContext : DbContext
    {
        public CasinoDbContext(DbContextOptions<CasinoDbContext> options)
           : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Bonus> Bons { get; set; }
        public DbSet<PlayerBonus> PlayerBonuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerBonus>()
                .HasKey(pb => new { pb.PlayerId, pb.BonusId });

            modelBuilder.Entity<PlayerBonus>()
                .HasOne(pb => pb.Player)
                .WithMany(p => p.PlayerBonuses)
                .HasForeignKey(pb => pb.PlayerId);

            modelBuilder.Entity<PlayerBonus>()
                .HasOne(pb => pb.Bonus)
                .WithMany(b => b.PlayerBonuses)
                .HasForeignKey(pb => pb.BonusId);
        }
    }
}
