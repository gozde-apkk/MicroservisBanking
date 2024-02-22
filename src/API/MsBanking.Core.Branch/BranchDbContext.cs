using Microsoft.EntityFrameworkCore;

namespace MsBanking.Core.Branch
{
    public class BranchDbContext : DbContext
    {
        public BranchDbContext(DbContextOptions<BranchDbContext> options) : base(options)
        {
        }

        public DbSet<MsBanking.Common.Entity.Branch> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MsBanking.Common.Entity.Branch>().ToTable("Branch");
            base.OnModelCreating(modelBuilder);
        }
    }

}
