using Microsoft.EntityFrameworkCore;

namespace MsBanking.Core.Account.Domain
{
    public static class DataSeeder
    {

        public static void Seed(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AccountDbContext>();

                if (context == null)
                    return;

                context.Database.Migrate();
                context.Database.EnsureCreated();

                if (!context.Accounts.Any())
                {
                    var accountList = new List<MsBanking.Common.Entity.Account>()
                    {
                        new Common.Entity.Account() { AccountNumber = "1234567890", AccountType="saving", IbanNumber = "TR1234567890",  Balance = 1000, Currency = "TRY", UserId = "1234567890", BranchId = 9019, AccountSuffix = 1,isActive=true },
                        new Common.Entity.Account() { AccountNumber = "1234567891", AccountType="saving", IbanNumber = "TR1234567891",  Balance = 1000, Currency = "TRY", UserId = "1234567891", BranchId = 9142, AccountSuffix = 1,isActive = true },
                        new Common.Entity.Account() { AccountNumber = "1234567892", AccountType="saving", IbanNumber = "TR1234567892", Balance = 1000, Currency = "TRY", UserId = "1234567892", BranchId = 9080, AccountSuffix = 1,isActive=true },
                    };

                    context.AddRange(accountList);
                    context.SaveChanges();
                }
            }
        }
    }
}
