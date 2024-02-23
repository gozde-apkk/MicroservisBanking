namespace MsBanking.Core.Account.Services
{
    public class AccountTransactionService
    {

        private readonly AccountDbContext db;


        public AccountTransactionService(AccountDbContext db)
        {
            this.db = db;
        }

    }
}
