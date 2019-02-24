using System;

namespace Domain.Entity
{
    public class Odds: BaseEntity
    {
        public int SiteId { get; set; }
        public DateTime UpdateTime { get; set; }
        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public int TeamId { get; set; }
        public double H2H0 { get; set; }
        public double H2H1 { get; set; }
        public double H2H2 { get; set; }
    }
}