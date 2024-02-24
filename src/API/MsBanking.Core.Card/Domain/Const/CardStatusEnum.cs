namespace MsBanking.Core.Card.Domain.Const
{
    public enum CardStatusEnum
    {
        Open = 1,
        Closed = 2
    }

    public enum CardVendorTypeEnum
    {
        Visa = 1,
        MasterCard = 2,
        Troy = 3,
        AmericanExpress = 4
    }
    public enum CardTypeEnum
    {
        CreditCard = 1,
        DebitCard = 2
    }

    public enum CardTransactionTypeEnum
    {
        Deposit = 1,
        Withdraw = 2,
    }
}
