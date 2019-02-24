using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public new DbSet<Bet> Bets { get; set; }
        public new DbSet<Category> Categories { get; set; }
        public new DbSet<Match> Matches { get; set; }
        public new DbSet<Odds> Odds { get; set; }
        public new DbSet<Result> Results { get; set; }
        public new DbSet<Site> Sites { get; set; }
        public new DbSet<Team> Teams { get; set; }
    }
}