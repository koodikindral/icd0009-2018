using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Domain.Entity
{
    public class User : IdentityUser<int>
    {
        public string Nickname { get; set; }
        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; }
        [JsonIgnore]
        public ICollection<Payment> Payments { get; set; }
    }
}
