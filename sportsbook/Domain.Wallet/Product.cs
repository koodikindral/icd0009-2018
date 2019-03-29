using System.Collections.Generic;
using DAL.Base.Entity;
using Newtonsoft.Json;

namespace Domain.Wallet
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; }
    }
}