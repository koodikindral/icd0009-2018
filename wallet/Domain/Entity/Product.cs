using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entity
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; }
    }
}