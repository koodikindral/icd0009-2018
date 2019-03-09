using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Odds> Odds { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}