using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entity
{
    public class Currency: BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; }
    }
}