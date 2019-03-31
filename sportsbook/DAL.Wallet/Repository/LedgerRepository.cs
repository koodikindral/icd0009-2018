using DAL.Base.Repository;
using DAL.Wallet.Repository.Interface;
using Domain.Wallet;

namespace DAL.Wallet.Repository
{
    public class LedgerRepository : BaseRepositoryAsync<Ledger>, ILedgerRepository
    {
        public LedgerRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}