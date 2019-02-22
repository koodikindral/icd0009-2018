using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entity
{
    public class Ledger: BaseEntity
    {
        public int AccountId { get; set; }
        public int LedgerTypeId { get; set; }
        public double Amount { get; set; }
        [JsonIgnore]
        public ICollection<Payment> Payments { get; set; }
    }
}