using System.Collections.Generic;
using DAL.Base.Entity;
using Newtonsoft.Json;

namespace Domain.Wallet
{
    public class Player : BaseEntity
    {
        public string Nickname { get; set; }
        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; }
        [JsonIgnore]
        public ICollection<Payment> Payments { get; set; }
    }
}
