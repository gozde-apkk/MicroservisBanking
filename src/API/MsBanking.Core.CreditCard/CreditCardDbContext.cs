using Microsoft.EntityFrameworkCore;

namespace MsBanking.Core.CreditCard
{
    public class CreditCardDbContext : DbContext
    {

        public CreditCardDbContext()
        {
            
        }

        public CreditCardDbContext(DbContextOptions<CreditCardDbContext> options) : base(options)
        {
        }

        public DbSet<MsBanking.Core.CreditCard.Domain.Entity.CreditCard> CreditCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entity.CreditCard>().ToTable("CreditCard");
        }
    }
}
