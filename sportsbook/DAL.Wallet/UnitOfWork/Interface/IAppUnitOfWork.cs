using DAL.Base.UnitOfWork.Interface;
using DAL.Wallet.Repository.Interface;

namespace DAL.Wallet.UnitOfWork.Interface
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IAccountRepository Accounts { get; }
        ICurrencyRepository Currencies { get; }
        ILedgerRepository Ledger { get; }
        IPaymentMethodRepository PaymentMethods { get; }
        IPaymentRepository Payments { get; }
        IProductRepository Products { get; }
    }
}