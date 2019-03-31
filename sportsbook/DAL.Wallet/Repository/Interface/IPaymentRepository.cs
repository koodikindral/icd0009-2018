using DAL.Base.Repository.Interface;
using Domain.Wallet;

namespace DAL.Wallet.Repository.Interface
{
    public interface IPaymentRepository: IBaseRepositoryAsync<Payment, int>
    {
        
    }
}