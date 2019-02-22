using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Account: BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CurrencyId { get; set; }
    }
}