using System.Linq;
using Domain.Identity;
using Domain.Sportsbook;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Sportsbook
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // disable cascade delete
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
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
