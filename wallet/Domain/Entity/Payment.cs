namespace Domain.Entity
{
    public class Payment: BaseEntity
    {
        public int UserId { get; set; }
        public int PaymentMethodId { get; set; }
        public double Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int LedgerId { get; set; }
    }
}