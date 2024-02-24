using Microsoft.EntityFrameworkCore;

namespace MsBanking.Core.Card
{
    public class CardDbContext : DbContext
    {

        public CardDbContext()
        {
            
        }

        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options)
        {
        }

        public DbSet<MsBanking.Core.Card.Domain.Entity.Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MsBanking.Core.Card.Domain.Entity.Card>().ToTable("Card");
            modelBuilder.Entity<Domain.Entity.Card>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<Domain.Entity.Card>().Property(x => x.CreditLimit).HasPrecision(18, 4);
        }
    }
}
