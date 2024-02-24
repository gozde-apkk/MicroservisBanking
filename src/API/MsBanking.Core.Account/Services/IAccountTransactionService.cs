using MsBanking.Core.Account.Domain.Dto;

namespace MsBanking.Core.Account.Services
{
    public interface IAccountTransactionService
    {
        Task<AccountTransactionResponseDto> CreateAccountTransaction(AccountTransactionRequestDto accountTransaction);
        Task<List<AccountTransactionRequestDto>> GetAllTransanctions(int accountId);
    }
}