using System.ComponentModel;

namespace Domain.Wallet
{
    public enum PaymentStatus
    {
        [Description("Created")] Created,
        [Description("Approved")] Approved,
        [Description("Declined")] Declined
    }
}