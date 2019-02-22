using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entity
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