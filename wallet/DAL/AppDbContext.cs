using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public new DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Ledger> Ledger { get; set; }
        public DbSet<LedgerType> LedgerTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Sportsbook"
                }
            );
            modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    Id = 1,
                    Code = "EUR",
                    Name = "Euro"
                }
            );
            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod
                {
                    Id = 1,
                    Name = "mPesa",
                    DepositAllowed = true,
                    WithdrawAllowed = true
                }
            );
            modelBuilder.Entity<LedgerType>().HasData(
                new LedgerType
                {
                    Id = 1,
                    Name = "Payment"
                }
            );
        }
    }
}