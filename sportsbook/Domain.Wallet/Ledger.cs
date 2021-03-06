using System.Collections.Generic;
using DAL.Base.Entity;
using Newtonsoft.Json;

namespace Domain.Wallet
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