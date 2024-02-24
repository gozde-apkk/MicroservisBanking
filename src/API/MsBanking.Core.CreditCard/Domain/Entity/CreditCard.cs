using MsBanking.Common.Entity;

namespace MsBanking.Core.CreditCard.Domain.Entity
{
    public class CreditCard : BaseEntity
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string Cvv { get; set; }
        public int CardVendorType { get; set; }
        public int CardType { get; set; }
        public int CardStatus { get; set; }
        public string UserId { get; set; }
        public string CreditLimit { get; set; }
    }
}
