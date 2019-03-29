using DAL.Base.Repository;
using DAL.Wallet.Repository.Interface;
using Domain.Wallet;

namespace DAL.Wallet.Repository
{
    public class AccountRepository : BaseRepositoryAsync<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}