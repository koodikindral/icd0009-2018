using DAL.Base.Repository;
using Domain.Wallet;

namespace DAL.Wallet.Repository.Interface
{
    public interface IAccountRepository: IBaseRepositoryAsync<Account, int>
    {
        
    }
}