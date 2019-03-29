using System.Collections.Generic;
using DAL.Base.Entity;
using Newtonsoft.Json;

namespace Domain.Wallet
{
    public class Currency: BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; }
    }
}