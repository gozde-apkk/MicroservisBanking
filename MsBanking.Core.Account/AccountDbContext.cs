using Microsoft.EntityFrameworkCore;
using MsBanking.Core.Account.Domain.Entity;

namespace MsBanking.Core.Account
{
    public class AccountDbContext : DbContext
    {

        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
        }

        public DbSet<MsBanking.Common.Entity.Account> Accounts { get; set; }
        public DbSet<MsBanking.Core.Account.Domain.Entity.AccountTransactions> AccountTransactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MsBanking.Common.Entity.Account>().ToTable("Account");
            modelBuilder.Entity<MsBanking.Common.Entity.Account>().HasQueryFilter(x => x.isActive);

            modelBuilder.Entity<AccountTransactions>().ToTable("AccountTransaction");

            modelBuilder.Entity<AccountTransactions>()
                .HasOne(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.AccountId);
        }
    }
}
