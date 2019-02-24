using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entity
{
    public class Site: BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Odds> Odds { get; set; }
    }
}