using DAL.Base.Repository;
using DAL.Wallet.Repository.Interface;
using Domain.Wallet;

namespace DAL.Wallet.Repository
{
    public class ProductRepository : BaseRepositoryAsync<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}