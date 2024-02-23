using MsBanking.Common.Dto;

namespace MsBanking.Core.Account.Services
{
    public interface IAccountService
    {
        Task<AccountResponseDto> CreateAccount(AccountDto account);
        Task<AccountResponseDto> GetAccount(int id);
        Task<List<AccountResponseDto>> GetAccounts();
    }
}