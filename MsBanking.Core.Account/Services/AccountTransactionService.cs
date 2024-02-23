using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MsBanking.Core.Account.Domain.Const;
using MsBanking.Core.Account.Domain.Dto;

namespace MsBanking.Core.Account.Services
{
    public class AccountTransactionService : IAccountTransactionService
    {


        private readonly AccountDbContext db;
        private readonly IMapper mapper;

        public AccountTransactionService(AccountDbContext _db, IMapper _mapper)
        {
            this.mapper = _mapper;
            db = _db;
        }


        public async Task<List<AccountTransactionRequestDto>> GetAllTransanctions(int accountId)
        {

            var accountTransactions = await db.AccountTransactions.Where(x => x.AccountId == accountId).ToListAsync();
            var accountTransactionResponse = mapper.Map<List<AccountTransactionRequestDto>>(accountTransactions);
            return accountTransactionResponse;
        }


        public async Task<AccountTransactionResponseDto> CreateAccountTransaction(AccountTransactionRequestDto accountTransaction)
        {
            var accTran = mapper.Map<MsBanking.Core.Account.Domain.Entity.AccountTransactions>(accountTransaction);

            if (accTran.TransactionType == (int)TransactionTypeEnum.Deposit)
            {
                await DepositToAccount(accTran.AccountId, accTran.Amount);
            }
            else if (accTran.TransactionType == (int)TransactionTypeEnum.Withdraw)
            {
                await WithdrawFromAccount(accTran.AccountId, accTran.Amount);
            }
            else if (accTran.TransactionType == (int)TransactionTypeEnum.Transfer && accTran.ToAccountId.HasValue)
            {
                await TransferToAccount(accTran.AccountId, accTran.ToAccountId.Value, accTran.Amount);
            }


            accTran.TransactionDate = DateTime.Now;
            accTran.isActive = true;
            accTran.CreatedDate = DateTime.Now;
            accTran.UpdatedDate = DateTime.Now;

            db.AccountTransactions.Add(accTran);
            await db.SaveChangesAsync();

            var accountTransactionResponse = mapper.Map<AccountTransactionResponseDto>(accTran);

            var account = await db.Accounts.FindAsync(accountTransaction.AccountId);
            accountTransactionResponse.TotalBalance = account.Balance;

            return accountTransactionResponse;
        }

        private async Task DepositToAccount(int accountId, decimal amount)
        {

            var account = await db.Accounts.FindAsync(accountId);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            account.Balance += amount;
            await db.SaveChangesAsync();
        }

        private async Task WithdrawFromAccount(int accountId, decimal amount)
        {

            var account = await db.Accounts.FindAsync(accountId) ?? throw new Exception("Account not found");
            if (account != null && account.Balance < amount)
            {
                throw new Exception("Insufficient balance");
            }
            account.Balance -= amount;
            await db.SaveChangesAsync();
        }

        private async Task TransferToAccount(int fromAccountId, int toAccountId, decimal amount)
        {
            await WithdrawFromAccount(fromAccountId, amount);
            await DepositToAccount(toAccountId, amount);
        }

    }
}
