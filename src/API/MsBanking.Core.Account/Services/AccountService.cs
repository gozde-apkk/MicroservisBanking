using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MsBanking.Common.Dto;

namespace MsBanking.Core.Account.Services
{
    public class AccountService : IAccountService
    {

        private readonly AccountDbContext db;
        private readonly IMapper mapper;

        public AccountService(AccountDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public async Task<AccountResponseDto> CreateAccount(AccountDto account)
        {
            var newAccount = mapper.Map<MsBanking.Common.Entity.Account>(account);
            newAccount.CreatedDate = DateTime.Now;
            newAccount.UpdatedDate = DateTime.Now;
            newAccount.isActive = true;

            db.Accounts.Add(newAccount);
            await db.SaveChangesAsync();

            var accountResponse = mapper.Map<AccountResponseDto>(newAccount);
            return accountResponse;
        }
        public async Task<AccountResponseDto> GetAccount(int id)
        {
            var accountEntity = await db.Accounts.FindAsync(id);
            var accountResponse = mapper.Map<AccountResponseDto>(accountEntity);
            return accountResponse;
        }
        public async Task<List<AccountResponseDto>> GetAccounts()
        {
            var accountEntities = await db.Accounts.ToListAsync();
            var accountResponse = mapper.Map<List<AccountResponseDto>>(accountEntities);
            return accountResponse;
        }
    }
}
