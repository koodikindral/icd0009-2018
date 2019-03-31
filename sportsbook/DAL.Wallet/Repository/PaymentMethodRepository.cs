using DAL.Base.Repository;
using DAL.Wallet.Repository.Interface;
using Domain.Wallet;

namespace DAL.Wallet.Repository
{
    public class PaymentMethodRepository : BaseRepositoryAsync<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}