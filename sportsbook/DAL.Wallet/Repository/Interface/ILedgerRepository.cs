using DAL.Base.Repository.Interface;
using Domain.Wallet;

namespace DAL.Wallet.Repository.Interface
{
    public interface ILedgerRepository: IBaseRepositoryAsync<Ledger, int>
    {
        
    }
}