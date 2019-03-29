using DAL.Base.UnitOfWork;
using DAL.Wallet.Repository.Interface;

namespace DAL.Wallet.UnitOfWork.Interface
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IAccountRepository Accounts { get; }
    }
}