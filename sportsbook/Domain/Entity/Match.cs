using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entity
{
    public class Match: BaseEntity
    {
        public DateTime MatchTime { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Odds> Odds { get; set; }
    }
}