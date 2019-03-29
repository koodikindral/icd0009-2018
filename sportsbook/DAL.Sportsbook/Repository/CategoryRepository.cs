using DAL.Base.Repository;
using DAL.Sportsbook.Repository.Interface;
using Domain.Sportsbook;

namespace DAL.Sportsbook.Repository
{
    public class CategoryRepository: BaseRepositoryAsync<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}