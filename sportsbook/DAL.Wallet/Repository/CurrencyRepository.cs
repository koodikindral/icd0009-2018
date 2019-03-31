using DAL.Base.Repository;
using DAL.Wallet.Repository.Interface;
using Domain.Wallet;

namespace DAL.Wallet.Repository
{
    public class CurrencyRepository : BaseRepositoryAsync<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}