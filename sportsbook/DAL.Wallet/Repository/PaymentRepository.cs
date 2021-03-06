using DAL.Base.Repository;
using DAL.Wallet.Repository.Interface;
using Domain.Wallet;

namespace DAL.Wallet.Repository
{
    public class PaymentRepository : BaseRepositoryAsync<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}