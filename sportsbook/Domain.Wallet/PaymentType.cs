using System.ComponentModel;

namespace Domain.Wallet
{
    public enum PaymentType
    {
        [Description("Deposit")] Deposit,
        [Description("Withdraw")] Withdraw
    }
}