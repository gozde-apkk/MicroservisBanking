using Microsoft.EntityFrameworkCore;

namespace MsBanking.Core.Account
{
    public class AccountDbContext : DbContext
    {

        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
        }

        public DbSet<MsBanking.Common.Entity.Account> Accounts { get; set; }
    }
}
