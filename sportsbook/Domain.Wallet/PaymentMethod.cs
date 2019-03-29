using System.Collections.Generic;
using DAL.Base.Entity;
using Newtonsoft.Json;

namespace Domain.Wallet
{
    public class PaymentMethod: BaseEntity
    {
        public string Name { set; get; }
        public bool DepositAllowed { get; set; }
        public bool WithdrawAllowed { get; set; }
        [JsonIgnore]
        public ICollection<Payment> Payments { get; set; }
    }
}