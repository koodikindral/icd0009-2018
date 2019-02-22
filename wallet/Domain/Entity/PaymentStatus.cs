using System.ComponentModel;

namespace Domain.Entity
{
    public enum PaymentStatus
    {
        [Description("Created")] Created,
        [Description("Approved")] Approved,
        [Description("Declined")] Declined
    }
}