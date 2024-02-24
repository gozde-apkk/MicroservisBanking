using AutoMapper;

namespace MsBanking.Core.Account.Domain.Dto
{
    public class AccountTransactionResponseDto
    {
        public int AccountId { get; set; }
        public decimal TotalBalance { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
    }

    public class AccountTransactionRequestDto
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
        public int TransactionType { get; set; }
        public int? ToAccountId { get; set; }
    }

    public class AccountResponseRequestProfile : Profile
    {
        public AccountResponseRequestProfile()
        {
            CreateMap<AccountTransactionRequestDto, MsBanking.Core.Account.Domain.Entity.AccountTransactions>().ReverseMap();
            CreateMap<MsBanking.Core.Account.Domain.Entity.AccountTransactions, AccountTransactionResponseDto>().ReverseMap();
        }
    }
}
