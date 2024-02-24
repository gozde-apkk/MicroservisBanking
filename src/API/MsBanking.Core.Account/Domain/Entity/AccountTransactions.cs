using MsBanking.Common.Entity;

namespace MsBanking.Core.Account.Domain.Entity
{
    public class AccountTransactions : BaseEntity
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public MsBanking.Common.Entity.Account Account { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public int TransactionType { get; set; }
        public int? ToAccountId { get; set; }

    }
}
