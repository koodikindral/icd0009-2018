using System;

namespace Domain.Entity
{
    public class Result: BaseEntity
    {
        public DateTime ResultTime { get; set; }
        public int H2H0 { get; set; }
        public int H2H1 { get; set; }
        public int H2H2 { get; set; }
    }
}