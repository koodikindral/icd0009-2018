using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entity
{
    public class LedgerType: BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Ledger> Ledgers { get; set; }
    }
}