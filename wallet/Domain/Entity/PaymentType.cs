using System.ComponentModel;

namespace Domain.Entity
{
    public enum PaymentType
    {
        [Description("Deposit")] Deposit,
        [Description("Withdraw")] Withdraw
    }
}