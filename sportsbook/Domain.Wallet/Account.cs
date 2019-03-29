using DAL.Base.Entity;

namespace Domain.Wallet
{
    public class Account: BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CurrencyId { get; set; }
    }
}