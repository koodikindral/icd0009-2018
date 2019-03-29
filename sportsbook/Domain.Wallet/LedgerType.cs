using System.Collections.Generic;
using DAL.Base.Entity;
using Newtonsoft.Json;

namespace Domain.Wallet
{
    public class LedgerType: BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Ledger> Ledgers { get; set; }
    }
}