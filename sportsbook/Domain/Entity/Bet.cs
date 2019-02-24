using System;

namespace Domain.Entity
{
    public class Bet: BaseEntity
    {
        public int UserId { get; set; }
        public DateTime BetTime { get; set; }
        public double BetAmount { get; set; } 
        public BetType BetType {get;set;}
    }
}